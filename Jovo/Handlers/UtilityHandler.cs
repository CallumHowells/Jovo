using System;
using System.IO;

namespace Jovo
{
    public class UtilityHandler
    {
        public UtilityHandler() { }

        public void ArchiveLog()
        {
            try
            {
                FileInfo logFile = new FileInfo("log.txt");

                DateTime now = DateTime.Now;

                if (now.AddHours(-24) > logFile.CreationTime)
                {
                    LogEvent("Log file was archived", true, true);
                    if (!Directory.Exists("loghistory"))
                        Directory.CreateDirectory("loghistory");

                    logFile.MoveTo("loghistory\\log " + DateTime.Today.ToString("yyyy-MM-dd") + ".txt");
                }
            } catch(Exception) { }
        }

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
