using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
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


                        File.Create("log.txt").Close();
                        File.SetCreationTime("log.txt", DateTime.Now);
                    }
                }
            }
            catch (Exception ArchiveEx)
            {
                LogEvent(ArchiveEx.ToString());
            }
            finally
            {
                PurgeLogHistory();
            }
        }

        public void PurgeLogHistory()
        {
            try
            {
                if (Directory.Exists("loghistory"))
                {
                    foreach (string file in Directory.GetFiles("loghistory"))
                    {
                        FileInfo log = new FileInfo(file);
                        if (log.CreationTime < DateTime.Now.AddMonths(-1))
                        {
                            log.Delete();
                        }
                    }
                }
            }
            catch (Exception PurgeLogsEx)
            {
                LogEvent(PurgeLogsEx.ToString());
            }
        }

        public void LogEvent(string message, bool newLine = true, bool blankLine = false)
        {
            try
            {
                using (StreamWriter LogWriter = new StreamWriter(process.StartInfo.WorkingDirectory + "log.txt", true))
                {
                    if (LogWriter.BaseStream.Position == 0)

                        if (LogWriter.BaseStream.Position != 0 && blankLine)
                        {
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
            catch (Exception)
            {
            }
        }

        public bool TestConnection(string ipAddress)
        {
            IPAddress ip = null;

            try
            {
                if (ipAddress.Contains("\\"))
                    ip = Dns.GetHostEntry(ipAddress.Replace("\\", String.Empty)).AddressList[0];
                else if (ipAddress.Contains("http://"))
                    ip = Dns.GetHostAddresses(new Uri(ipAddress).Host)[0];
                else
                    ip = IPAddress.Parse(ipAddress);

                Ping p = new Ping();
                PingReply reply = p.Send(ip);

                if (reply.Status == IPStatus.Success)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
