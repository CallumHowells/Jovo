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
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ModuleHandler module = new ModuleHandler();
            UtilityHandler utility = new UtilityHandler();
            utility.ArchiveLog();

            utility.LogEvent("############################ Program starting... ############################", true, true);
            module.GetSetDirectoryStructure(System.Reflection.Assembly.GetEntryAssembly().Location);

            Application.Run(new formMain(module, utility));
        }
    }
}
