﻿using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using System.Linq;

namespace Jovo
{
    public class ModuleHandler
    {
        UtilityHandler utility = new UtilityHandler();

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
                if (data.IsConnected)
                {
                    utility.LogEvent("Trying to start module: " + data.Name);
                    if (File.Exists(data.Path + "\\" + data.Name + ".exe"))
                    {
                        Process.Start(data.Path + "\\" + data.Name + ".exe");
                        utility.LogEvent("... Success", false);
                        return true;
                    }
                    utility.LogEvent("... Failed (doesn't exist)", false);
                    return false;
                }
                else
                    return false;
            }
            catch (Exception)
            { return false; }
        }

        public ModuleData FindModule(string name) => InstalledModules.Find(m => m.Name == name);

        public void GetSetDirectoryStructure(string appDir)
        {
            AppPath = Path.GetDirectoryName(appDir);
            AppModulePath = AppPath + "\\modules";
            if (!Directory.Exists(AppModulePath))
                Directory.CreateDirectory(AppModulePath);

            if (!String.IsNullOrWhiteSpace(Jovo.Default.Module_Update_Remote_Path))
            {
                ServerPath = null;
                ServerModulePath = null;
            }
            else
            {
                ServerPath = Jovo.Default.Module_Update_Remote_Path;
                ServerModulePath = ServerPath + "Modules";
            }
            utility.LogEvent("Looking for module updates at: " + Jovo.Default.Module_Update_Remote_Path);

        }

        public void GetModules(bool log = false)
        {
            InstalledModules.Clear();
            foreach (string path in Directory.GetDirectories(AppModulePath))
            {
                if (File.Exists(path + "\\manifest.json"))
                {
                    ModuleData data = JsonConvert.DeserializeObject<ModuleData>(File.ReadAllText(path + "\\manifest.json"));
                    data.Path = path;
                    InstalledModules.Add(data);
                    if (log)
                        utility.LogEvent($"Found installed module: {data.Name} (v{data.Version})");

                }
            }
            if (log)
                utility.LogEvent(InstalledModules.Count + " modules loaded");
        }

        public void WriteModuleManifest(ModuleData module)
        {
            string manifestStr = JsonConvert.SerializeObject(module, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            });

            File.WriteAllText(module.Path + "\\manifest.json", manifestStr);
        }
        #endregion

        #region Settings
        public List<SettingData> GetModuleSettings(ModuleData data)
        {
            List<SettingData> moduleSettings = new List<SettingData>();

            if (File.Exists(data.Path + "\\settings.json"))
            {
                List<SettingData> tempSettings = JsonConvert.DeserializeObject<List<SettingData>>(File.ReadAllText(data.Path + "\\settings.json"));

                foreach (SettingData settings in tempSettings)
                {
                    settings.Module = data.Name;
                    moduleSettings.Add(settings);
                }

                return moduleSettings;
            }

            return null;
        }

        public bool SaveModuleSettings(ModuleData data, List<SettingData> settings)
        {
            File.Delete(data.Path + "\\settings.json");

            using (StreamWriter file = File.CreateText(data.Path + "\\settings.json"))
            {
                file.WriteLine(JsonConvert.SerializeObject(settings, Formatting.Indented));
            }

            return File.Exists(data.Path + "\\settings.json");
        }
        #endregion

        #region ServerSideModules
        public void GetServerModules()
        {
            ServerModulePath = Jovo.Default.Module_Update_Remote_Path;
            if (!String.IsNullOrWhiteSpace(ServerModulePath))
            {
                if (!ServerModulePath.EndsWith("\\"))
                    ServerModulePath += "\\";

                ServerModules.Clear();

                if (Directory.Exists(ServerModulePath))
                {
                    foreach (string path in Directory.GetDirectories(ServerModulePath))
                    {
                        if (File.Exists(path + "\\manifest.json"))
                        {
                            ModuleData data = JsonConvert.DeserializeObject<ModuleData>(File.ReadAllText(path + "\\manifest.json"));
                            data.Path = path;
                            ServerModules.Add(data);
                        }
                    }
                }
                else
                {
                    utility.LogEvent("Server module directory does not exist or is not visible from here");
                }
            }
        }

        public void GetModuleUpdates(UtilityHandler utility, BackgroundWorker worker, bool OutputResult = true)
        {
            GetModules();
            GetServerModules();

            foreach (ModuleData AvailableModule in ServerModules)
            {
                DirectoryInfo localDir = new DirectoryInfo(AppModulePath + "\\" + AvailableModule.Name);
                ModuleData InstalledModule = InstalledModules.Find(m => m == AvailableModule);

                if (!Directory.Exists(AppModulePath + "\\" + AvailableModule.Name))
                {
                    if (OutputResult)
                        utility.LogEvent("Installing module " + AvailableModule.Name);

                    worker.ReportProgress(0, new NotificationData() { Title = "Installing Module...", Text = AvailableModule.Name, Timeout = 5000, Method = "Show" });

                    Directory.CreateDirectory(AppModulePath + "\\" + AvailableModule.Name);
                    CopyAll(new DirectoryInfo(AvailableModule.Path), localDir, utility);

                    worker.ReportProgress(0, new NotificationData() { Method = "Hide" });
                }
                else if (AvailableModule > InstalledModule)
                {
                    utility.LogEvent($"Updating {InstalledModule.Name} v{InstalledModule.Version} to {AvailableModule.Version}");
                    worker.ReportProgress(0, new NotificationData() { Title = "Updating Module...", Text = AvailableModule.Name, Timeout = 5000, Method = "Show" });

                    CopyAll(new DirectoryInfo(AvailableModule.Path), localDir, utility);

                    ModuleData newModuleVersion = JsonConvert.DeserializeObject<ModuleData>(File.ReadAllText(AppModulePath + "\\" + InstalledModule.Name + "\\manifest.json"));
                    if (newModuleVersion.IsActive != InstalledModule.IsActive)
                    {
                        newModuleVersion.IsActive = InstalledModule.IsActive;

                        string json = JsonConvert.SerializeObject(newModuleVersion, Formatting.Indented);
                        File.WriteAllText(AppModulePath + "\\" + InstalledModule.Name + "\\manifest.json", json);
                    }

                    worker.ReportProgress(0, new NotificationData() { Method = "Hide" });
                }
            }

            if (ServerModules.Count > 0)
            {
                foreach (ModuleData data in InstalledModules)
                {
                    if (!ServerModules.Contains(data))
                    {
                        Directory.Delete(data.Path, true);
                        utility.LogEvent("Module not found on server (" + data.Name + "), Deleteing local module...");
                    }
                }
            }

            GetModules(OutputResult);
        }

        private void CopyAll(DirectoryInfo source, DirectoryInfo target, UtilityHandler utility)
        {
            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories().Where(x => (x.Name != "Previous Versions") && x.Name != "Ready To Deploy").ToList())
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir, utility);
            }
        }
        #endregion

        #region JovoUpdate
        public bool CheckForJovoUpdates(string remoteManifest)
        {
            VersionControl remote = JsonConvert.DeserializeObject<VersionControl>(File.ReadAllText(remoteManifest));
            VersionControl local = JsonConvert.DeserializeObject<VersionControl>(File.ReadAllText("manifest.json"));

            if (local.NewVersion(remote.version))
            {
                utility.LogEvent("Newer version of main application found!");
                return true;
            }
            else
                return false;
        }

        public void DoJovoUpdate(string updaterFileName)
        {
            utility.LogEvent("Trying to start application updater...");
            Process current = Process.GetCurrentProcess();

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                WorkingDirectory = Path.GetDirectoryName(updaterFileName),
                FileName = "Jovo.exe",
                Arguments = "\"" + current.Id.ToString() + "\""
            };

            Directory.SetCurrentDirectory(Path.GetDirectoryName(updaterFileName));
            Process Jovo = Process.Start(startInfo);

            Thread.Sleep(1000);

            Application.Exit();
        }
        #endregion

        #region ChangelogHandling
        public List<Changelog> GetModuleChangelog(ModuleData data)
        {
            List<Changelog> change = new List<Changelog>();

            string path = (data == null) ? Application.StartupPath + "\\changelog.json" : data.Path + "\\changelog.json";

            if (File.Exists(path))
            {
                try
                {
                    change = JsonConvert.DeserializeObject<List<Changelog>>(File.ReadAllText(path));
                }
                catch (Exception)
                { return null; }

                return change;
            }
            return null;
        }
        #endregion
    }


    public class ModuleData
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Text { get; set; }
        public int Category { get; set; }
        public string Version { get; set; }
        public string PublishDate { get; set; }
        public string Info { get; set; }
        public bool HasSettings { get; set; } = false;
        public bool CreateMenuItem { get; set; } = true;
        public bool IsActive { get; set; } = true;
        public string RequiresNetwork { get; set; } = "";
        public string KeyboardShortcut { get; set; } = "";

        [JsonIgnore]
        public bool IsConnected { get; set; } = true;
        [JsonIgnore]
        public string Path { get; set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as ModuleData);
        }

        public bool Equals(ModuleData m)
        {
            if (ReferenceEquals(m, null))
            {
                return false;
            }

            if (ReferenceEquals(this, m))
            {
                return true;
            }

            if (m == null || GetType() != m.GetType())
            {
                return false;
            }

            return (Name == m.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public static bool operator ==(ModuleData left, ModuleData right)
        {
            if (Object.ReferenceEquals(left, null))
            {
                if (Object.ReferenceEquals(right, null))
                {
                    return true;
                }

                return false;
            }

            return left.Equals(right);
        }

        public static bool operator !=(ModuleData left, ModuleData right)
        {
            return !(left == right);
        }

        public static bool operator <(ModuleData left, ModuleData right)
        {
            if (ReferenceEquals(left, null))
            {
                if (ReferenceEquals(right, null))
                {
                    return true;
                }

                return false;
            }

            if (left != right)
            {
                return false;
            }

            if (new Version(left.Version) < new Version(right.Version))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator >(ModuleData left, ModuleData right)
        {
            if (ReferenceEquals(left, null))
            {
                if (ReferenceEquals(right, null))
                {
                    return true;
                }

                return false;
            }

            if (left != right)
            {
                return false;
            }

            if (new Version(left.Version) > new Version(right.Version))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class SettingData
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Domain { get; set; }
        public string Value { get; set; }

        [JsonIgnore]
        public string Module { get; set; }
    }

    public class NotificationData
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int Timeout { get; set; }
        public string Method { get; set; }
    }

    public class VersionControl
    {
        public Version version { get; set; }

        public bool NewVersion(string External)
        {
            Version vExternal; Version.TryParse(External, out vExternal);

            if (vExternal > version)
                return true;
            else
                return false;
        }

        public bool NewVersion(Version External)
        {
            if (External > version)
                return true;
            else
                return false;
        }
    }

    public class Changelog
    {
        public string Version { get; set; }
        public string VersionDate { get; set; } = "";
        public string Title { get; set; }
        public string Description { get; set; } = "";
        public string Author { get; set; } = "";
        public string Tags { get; set; } = "";
        public List<ChangelogChange> Changes { get; set; }

    }

    public class ChangelogChange
    {
        public string Title { get; set; }
        public string Type { get; set; }
    }
}