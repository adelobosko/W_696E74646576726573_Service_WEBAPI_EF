using System;
using System.Collections.Generic;
using System.IO;
using System.Management;

namespace W_Service
{
    public static class InfoHelper
    {
        public static string GetPCName()
        {
            return Environment.MachineName;
        }
        public static IEnumerable<string> GetUsers()
        {
            var query = new ManagementObjectSearcher("SELECT LocalPath FROM Win32_UserProfile WHERE Loaded = True");

            var listUsers = new List<string>();
            foreach (ManagementObject mo in query.Get())
            {
                listUsers.Add(Path.GetFileName(mo["LocalPath"].ToString()));
            }

            return listUsers;
        }
        public static string GetManufacturer()
        {
            var query = new ManagementObjectSearcher("SELECT Manufacturer FROM Win32_ComputerSystem");

            var manufacturer = "fail";
            foreach (var mo in query.Get())
            {
                manufacturer = mo["Manufacturer"].ToString();
            }

            return manufacturer;
        }
        public static IEnumerable<Tuple<string, string>> GetCPULoad()
        {
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PerfFormattedData_PerfOS_Processor");

            var list = new List<Tuple<string, string>>();
            foreach (var o in searcher.Get())
            {
                var obj = (ManagementObject)o;
                list.Add(new Tuple<string, string>(obj["Name"].ToString(), obj["PercentProcessorTime"].ToString()));
            }

            return list;
        }
        public static string GetRAMLoad()
        {
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            string percentage = "fail";
            foreach (var obj in searcher.Get())
            {
                var free = Double.Parse(obj["FreePhysicalMemory"].ToString());
                var total = Double.Parse(obj["TotalVisibleMemorySize"].ToString());
                percentage = $"{Math.Round(((total - free) / total * 100), 2)}%";
            }
            return percentage;
        }
    }
}
