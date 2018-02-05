using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jovo
{
    public class ModuleHandler
    {
        public ModuleHandler() { }

        public string AppPath { get; set; }
        public string ModulePath { get; set; }
        public List<ModuleData> InstalledModules = new List<ModuleData>();
        public List<ModuleData> ServerModules = new List<ModuleData>();
        public string ServerPath { get; set; }
        public string ServerModulePath { get; set; }

        public bool ExecuteModule(string name)
        {
            try
            {
                return true;
            }
            catch (Exception)
            { return false; }
        }

        public void GetSetDirectoryStructure(string appDir)
        {
            AppPath = Path.GetDirectoryName(appDir);
            ModulePath = AppPath + "\\modules";
            if (!Directory.Exists(ModulePath))
                Directory.CreateDirectory(ModulePath);

            ServerPath = @"\\itsql\C$\Weightron\Jovo\";
            ServerModulePath = ServerPath + "\\Modules";
        }

        public void GetModules()
        {
            //Console.WriteLine("Getting installed modules");
            InstalledModules.Clear();
            JsonSerializer serializer = new JsonSerializer();

            foreach (string path in Directory.GetDirectories(ModulePath))
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

        public JObject GetModuleSettings(ModuleData data)
        {
            if (File.Exists(data.Path + "\\settings.json"))
            {
                JToken tkn = JObject.Parse(File.ReadAllText(data.Path + "\\settings.json"));
                JObject obj = tkn.Value<JObject>();
                return obj;
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

        public void GetServerModules()
        {
            //Console.WriteLine("Getting server modules");
            ServerModules.Clear();
            JsonSerializer serializer = new JsonSerializer();

            foreach (string path in Directory.GetDirectories(ServerModulePath))
            {

                if (File.Exists(path + "\\manifest.json"))
                {
                    ModuleData data = JsonConvert.DeserializeObject<ModuleData>(File.ReadAllText(path + "\\manifest.json"));
                    data.Path = path;
                    data.Tag = (object)data;
                    ServerModules.Add(data);
                    //Console.WriteLine("Added " + data.Name);
                }
            }
        }

        public void GetModuleUpdates()
        {
            //Console.WriteLine("Updater...");
            GetModules();
            GetServerModules();
            //Console.WriteLine("Got modules... Trying move");
            foreach (ModuleData AvailableModule in ServerModules)
            {
                DirectoryInfo localDir = new DirectoryInfo(ModulePath + "\\" + AvailableModule.Name);

                if (!Directory.Exists(ModulePath + "\\" + AvailableModule.Name))
                {
                    Directory.CreateDirectory(ModulePath + "\\" + AvailableModule.Name);

                    CopyAll(new DirectoryInfo(AvailableModule.Path), localDir);
                } else if (CompareModuleVersions(AvailableModule))
                {
                    CopyAll(new DirectoryInfo(AvailableModule.Path), localDir);
                } else
                {
                    Console.WriteLine("Didn't update, up to date");
                }

                //Console.WriteLine(AvailableModule.Path + " -> " + localDir);
            }
            GetModules();
        }

        private bool CompareModuleVersions(ModuleData module)
        {
            foreach (ModuleData InstalledModule in InstalledModules)
            {
                if(InstalledModule.Name == module.Name)
                {
                    Version InstalledVersion = new Version(InstalledModule.Version);
                    Version ServerVersion = new Version(module.Version);
                    if(InstalledVersion < ServerVersion)
                    {
                        return true;
                    }
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
    }


    public class ModuleData
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Text { get; set; }
        public object Tag { get; set; }
        public string Version { get; set; }
        public string PublishDate { get; set; }
        public string Path { get; set; }
        public string Info { get; set; }
    }

}
