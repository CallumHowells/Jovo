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

            utility.LogEvent("Args received : " + args.Length);

            foreach (string arg in args)
            {
                utility.LogEvent("Start Argument : " + arg);
            }

            if (args.Length >= 2)
            {
                Jovo.Default.Jovo_Updater_Local_Path = args[0].Trim('"');
                Jovo.Default.Jovo_Update_Remote_Path = args[1].Trim('"');
                Jovo.Default.Save();
            }

            Application.Run(new formMain(module, utility));
        }
    }
}
