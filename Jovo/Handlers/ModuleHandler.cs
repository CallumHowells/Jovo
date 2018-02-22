using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace Jovo
{
    public class ModuleHandler
    {
        public ModuleHandler() { }

        public string AppPath { get; set; }
        public string AppModulePath { get; set; }
        public string ServerPath { get; set; }
        public string ServerModulePath { get; set; }
        public List<ModuleData> InstalledModules = new List<ModuleData>();
        public List<ModuleData> ServerModules = new List<ModuleData>();


        #region InternalModules
        public bool ExecuteModule(ModuleData data)
        {
            try
            {
                if (File.Exists(data.Path + "\\" + data.Name + ".exe"))
                {
                    Process.Start(data.Path + "\\" + data.Name + ".exe");
                    return true;
                }
                return false;
            }
            catch (Exception)
            { return false; }
        }

        public ModuleData FindModule(string name)
        {
            foreach (ModuleData data in InstalledModules)
            {
                if (data.Name == name)
                    return data;
            }
            return null;
        }

        public void GetSetDirectoryStructure(string appDir)
        {
            AppPath = Path.GetDirectoryName(appDir);
            AppModulePath = AppPath + "\\modules";
            if (!Directory.Exists(AppModulePath))
                Directory.CreateDirectory(AppModulePath);

            if (!String.IsNullOrWhiteSpace(Jovo.Default.Path_Server_Update))
            {
                ServerPath = null;
                ServerModulePath = null;
            }
            else
            {
                ServerPath = Jovo.Default.Path_Server_Update;
                ServerModulePath = ServerPath + "Modules";
            }
        }

        public void GetModules()
        {
            InstalledModules.Clear();

            foreach (string path in Directory.GetDirectories(AppModulePath))
            {
                if (File.Exists(path + "\\manifest.json"))
                {
                    ModuleData data = JsonConvert.DeserializeObject<ModuleData>(File.ReadAllText(path + "\\manifest.json"));
                    data.Path = path;
                    data.Tag = (object)data;
                    InstalledModules.Add(data);
                }
            }
        }
        #endregion

        #region Settings
        public List<SettingData> GetModuleSettings(ModuleData data)
        {
            List<SettingData> moduleSettings = new List<SettingData>();
            moduleSettings.Clear();

            if (File.Exists(data.Path + "\\settings.json"))
            {
                JToken tkn = JObject.Parse(File.ReadAllText(data.Path + "\\settings.json"));
                JObject obj = tkn.Value<JObject>();

                foreach (KeyValuePair<string, JToken> setting in obj)
                {
                    SettingData settings = JsonConvert.DeserializeObject<SettingData>(setting.Value.ToString());
                    settings.Module = data.Name;
                    moduleSettings.Add(settings);
                }

                return moduleSettings;
            }

            return null;
        }

        public bool SaveModuleSettings(ModuleData data, JObject json)
        {
            File.Delete(data.Path + "\\settings.json");

            using (StreamWriter file = File.CreateText(data.Path + "\\settings.json"))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                json.WriteTo(writer);
            }

            return File.Exists(data.Path + "\\settings.json");
        }
        #endregion

        #region ServerSideModules
        public void GetServerModules()
        {

            if (!String.IsNullOrWhiteSpace(ServerModulePath))
            {
                ServerModules.Clear();
                JsonSerializer serializer = new JsonSerializer();
                if(Directory.Exists(ServerModulePath)){
                foreach (string path in Directory.GetDirectories(ServerModulePath))
                {
                    if (File.Exists(path + "\\manifest.json"))
                    {
                        ModuleData data = JsonConvert.DeserializeObject<ModuleData>(File.ReadAllText(path + "\\manifest.json"));
                        data.Path = path;
                        data.Tag = (object)data;
                        ServerModules.Add(data);
                    }
                }
            }
        }
        public void GetModuleUpdates()
        {
            GetModules();
            GetServerModules();
            foreach (ModuleData AvailableModule in ServerModules)
            {
                DirectoryInfo localDir = new DirectoryInfo(AppModulePath + "\\" + AvailableModule.Name);

                if (!Directory.Exists(AppModulePath + "\\" + AvailableModule.Name))
                {
                    Directory.CreateDirectory(AppModulePath + "\\" + AvailableModule.Name);

                    CopyAll(new DirectoryInfo(AvailableModule.Path), localDir);
                }
                else if (CompareModuleVersions(AvailableModule))
                {
                    CopyAll(new DirectoryInfo(AvailableModule.Path), localDir);
                }
            }
            GetModules();
        }

        private bool CompareModuleVersions(ModuleData module)
        {
            foreach (ModuleData InstalledModule in InstalledModules)
            {

  try {
                if (InstalledModule.Name == module.Name)
                {
                    Version InstalledVersion = new Version(InstalledModule.Version);
                    Version ServerVersion = new Version(module.Version);
                    if (InstalledVersion < ServerVersion)
                    {
                        Version InstalledVersion = new Version(InstalledModule.Version);
                        Version ServerVersion = new Version(module.Version);
                        if (InstalledVersion < ServerVersion)
                        {
                            return true;
                        }
                    }
                }
                catch (Exception VersionCheckException)
                {
                    Console.WriteLine(VersionCheckException.Message);
                }
            }
            return false;
        }

        private void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
        #endregion
    }


    public class ModuleData
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Text { get; set; }
        public object Tag { get; set; }
        public int Category { get; set; }
        public string Version { get; set; }
        public string PublishDate { get; set; }
        public string Path { get; set; }
        public string Info { get; set; }
    }

    public class SettingData
    {
        public string Module { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Domain { get; set; }
        public string Value { get; set; }
    }

}
