using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Jovo
{
    public class UtilityHandler
    {
        static Process process = Process.GetCurrentProcess();
        string FullPath;

        public UtilityHandler() => FullPath = process.MainModule.FileName;

        public void ArchiveLog()
        {
            try
            {
                if (File.Exists("log.txt"))
                {
                    DateTime now = DateTime.Now;
                    DateTime FileCreated = File.GetCreationTime("log.txt");

                    if (now > FileCreated.AddDays(7))
                    {
                        LogEvent("Log file is being archived", true, true);
                        if (!Directory.Exists("loghistory"))
                            Directory.CreateDirectory("loghistory");


                        if (!File.Exists("loghistory\\log " + FileCreated.Date.ToString("yyyy-MM-dd") + ".txt"))
                        {
                            File.Move("log.txt", "loghistory\\log " + FileCreated.Date.ToString("yyyy-MM-dd") + ".txt");
                        }
                        else
                        {
                            File.AppendAllText("loghistory\\log " + FileCreated.Date.ToString("yyyy-MM-dd") + ".txt", File.ReadAllText("log.txt"));
                        }

                        File.Create("log.txt");
                        File.SetCreationTime("log.txt", DateTime.Now);
                    }
                }
            }
            catch (Exception ArchiveEx)
            {
                LogEvent(ArchiveEx.ToString());
            }
        }

        public void LogEvent(string message, bool newLine = true, bool blankLine = false)
        {
            using (StreamWriter LogWriter = new StreamWriter(process.StartInfo.WorkingDirectory + "log.txt", true))
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
