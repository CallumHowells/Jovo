using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jovo
{
    public class UtilityHandler
    {
        public UtilityHandler() { }

        public void LogEvent(string message, bool newLine = true, bool blankLine = false)
        {
            using (StreamWriter LogWriter = new StreamWriter("log.txt", true))
            {
                if (blankLine)
                    LogWriter.WriteLine("");

                if (!String.IsNullOrEmpty(message))
                {
                    string output = DateTime.Now.ToString() + " - " + message;

                    if (newLine)
                        LogWriter.WriteLine(output);
                    else
                        LogWriter.Write(output);
                }
            }
        }


    }
}
