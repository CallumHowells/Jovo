using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Jovo
{
    public class ModuleHandler
    {
        public ModuleHandler() { }

        public string AppPath { get; set; }
        public string ModulePath { get; set; }
        public List<ModuleData> Modules = new List<ModuleData>();

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
        }

        public void GetModules()
        {
            JsonSerializer serializer = new JsonSerializer();

            foreach (string path in Directory.GetDirectories(ModulePath))
            {
                if (File.Exists(path + "\\manifest.json"))
                {
                        ModuleData data = JsonConvert.DeserializeObject<ModuleData>(File.ReadAllText(path + "\\manifest.json"));
                        data.Path = path;
                        Modules.Add(data);
                }
            }
        }

    }
    

    public class ModuleData
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Text { get; set; }
        public string Tag { get; set; }
        public string Version { get; set; }
        public string PublishDate { get; set; }
        public string Path { get; set; }
    }

}
