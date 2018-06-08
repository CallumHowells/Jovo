using System;
using System.Windows.Forms;

namespace Jovo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ModuleHandler module = new ModuleHandler();
            UtilityHandler utility = new UtilityHandler();
            utility.ArchiveLog();

            utility.LogEvent("############################ Program starting... ############################", true, true);
            module.GetSetDirectoryStructure(System.Reflection.Assembly.GetEntryAssembly().Location);

            if (args.Length > 0)
            {
                Jovo.Default.Path_Jovo_Update = args[0];
                Jovo.Default.Save();
            }

            Application.Run(new formMain(module, utility));
        }
    }
}
