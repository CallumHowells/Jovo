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
                DateTime FileCreated = logFile.CreationTime;

                if (now > FileCreated.AddDays(7))
                {
                    LogEvent("Log file is being archived", true, true);
                    if (!Directory.Exists("loghistory"))
                        Directory.CreateDirectory("loghistory");

                    logFile.MoveTo("loghistory\\log " + FileCreated.Date.ToString("yyyy-MM-dd") + ".txt");
                    logFile.Delete();
                }
            } catch (Exception ArchiveEx)
            {
                LogEvent(ArchiveEx.ToString());
            }
        }

        public void LogEvent(string message, bool newLine = true, bool blankLine = false)
        {
            if (!File.Exists("log.txt"))
            {
                File.Create("log.txt");
                File.SetCreationTime("log.txt", DateTime.Now);
            }

            using (StreamWriter LogWriter = new StreamWriter("log.txt", true))
            {
                if (LogWriter.BaseStream.Position != 0)
                {
                    if (blankLine)
                        LogWriter.WriteLine("");
                }

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
