using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.IO;
using System.Net.Mail;
using System.Security.Principal;

namespace Jovo
{
    public class SystemFunctions
    {
        private static SystemFunctions inst;

        private SystemFunctions() { }

        public static SystemFunctions Inst
        {
            get
            {
                if (inst == null)
                {
                    inst = new SystemFunctions();
                }
                return inst;
            }
        }

        public string GetMACAddress(bool WithColons)
        {
            if (WithColons)
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                String sMacAddress = string.Empty;
                foreach (NetworkInterface adapter in nics)
                {
                    if (sMacAddress == String.Empty)// only return MAC Address from first card  
                    {
                        IPInterfaceProperties properties = adapter.GetIPProperties();
                        sMacAddress = adapter.GetPhysicalAddress().ToString();
                    }
                }

                string xMacAddress = sMacAddress.Substring(0, 2) + ":" + sMacAddress.Substring(2, 2) + ":" + sMacAddress.Substring(4, 2) + ":" + sMacAddress.Substring(6, 2) + ":" + sMacAddress.Substring(8, 2) + ":" + sMacAddress.Substring(10, 2);
                return xMacAddress;
            }
            else
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                String sMacAddress = string.Empty;
                foreach (NetworkInterface adapter in nics)
                {
                    if (sMacAddress == String.Empty)// only return MAC Address from first card  
                    {
                        IPInterfaceProperties properties = adapter.GetIPProperties();
                        sMacAddress = adapter.GetPhysicalAddress().ToString();
                    }
                }
                return sMacAddress;
            }
        }

        public string GetIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }

        public string GetPCName()
        {
            return Environment.MachineName;
        }

        public bool ExportDataTableToCSV(DataTable Table, string Seperator, string Output_Path, bool Overwrite)
        {
            // ***************** WARNING ***************** \\
            // This function requires .NET Framework v4.5+ \\
            // ******************************************* \\

            try
            {
                // If Overwrite = True, delete the file before the new one is written
                if (Overwrite)
                    if (File.Exists(Output_Path))
                        File.Delete(Output_Path);

                // Define local variables for the export
                List<string> LinesToWrite = new List<string>();
                string ColumnHeaders = "";
                string RowValues = "";

                // Count through all columns and add them to the top of the CSV
                for (int i = 0; i < Table.Columns.Count; i++)
                {
                    // If 'i' is the last column then only add the name, else add the seperator
                    if (i != Table.Columns.Count - 1)
                        ColumnHeaders = ColumnHeaders + Table.Columns[i].ColumnName + Seperator;
                    else
                        ColumnHeaders = ColumnHeaders + Table.Columns[i].ColumnName;
                }
                // Add the Column Headers to the list ready for writing to the file...
                LinesToWrite.Add(ColumnHeaders);

                // Cycle row bvy row through the table and add it to the CSV
                foreach (DataRow row in Table.Rows)
                {
                    // Clear the row value before each row starts processing
                    RowValues = "";

                    for (int j = 0; j < Table.Columns.Count; j++)
                    {
                        if (j != Table.Columns.Count - 1)
                            RowValues = RowValues + Convert.ToString(row[j]) + Seperator;
                        else
                            RowValues = RowValues + Convert.ToString(row[j]);
                    }
                    // Add the Row Values to the list ready for writing to the file...
                    LinesToWrite.Add(RowValues);
                }

                // Finally, write the file to the Output_Path
                File.AppendAllLines(Output_Path, LinesToWrite);
            }
            catch (Exception ex)
            {
                // If an error occurs return false
                Console.WriteLine(ex);
                return false;
            }

            // Check if the file exists, if not the process failed and returns false
            if (File.Exists(Output_Path))
                return true;
            else
                return false;
        }

        public string GetInstType()
        {
            return "A";
        }
        
        public bool IsUserAdministrator()
        {
            //bool value to hold our return value
            bool isAdmin;
            try
            {
                //get the currently logged in user
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException ex)
            {
                isAdmin = false;
            }
            catch (Exception ex)
            {
                isAdmin = false;
            }
            return isAdmin;
        }
    }
}
