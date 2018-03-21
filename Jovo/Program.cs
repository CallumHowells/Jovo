using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            module.GetSetDirectoryStructure(System.Reflection.Assembly.GetEntryAssembly().Location);

            Application.Run(new formMain(module, utility));
        }
    }
}
