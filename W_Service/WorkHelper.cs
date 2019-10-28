using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace W_Service
{
    internal static class WorkHelper
    {
        private static string logfile = @"E:\log.txt";
        public static void LogSysInfo()
        {
            try
            {
                var cpuLoadList = InfoHelper.GetCPULoad();
                var loogedUsers = InfoHelper.GetLoggedUsers();
                var sysInfoDM = new SysInfoDM()
                {
                    Id = Guid.NewGuid(),
                    Manufacturer = InfoHelper.GetManufacturer(),
                    PCName = InfoHelper.GetPCName(),
                    RAMLoad = InfoHelper.GetRAMLoad(),
                    DateTimeLog = DateTime.Now
                };


                sysInfoDM.CPULogs = cpuLoadList.Select(item => new CpuLogDM()
                { Id = Guid.NewGuid(), Name = item.Item1, Percentage = item.Item2 }).ToList();

                sysInfoDM.LoggedUsersLogs = loogedUsers
                    .Select(item => new LoggedUsersLogDM() { Id = Guid.NewGuid(), Name = item }).ToList();

               
                WebHelper.Put(sysInfoDM, "https://localhost:44377/api/SysInfo");
                Log($"SysInfo is sent!");
            }
            catch (Exception ex)
            {
                Log($"ERROR LogSysInfo():\r\n{ex.Message}");
            }

        }

        public static void Log(string text)
        {
            var str = $"[{DateTime.Now.ToString()}]    {text}\r\n";
            try
            {
                if (File.Exists(logfile))
                {
                    File.AppendAllText(logfile, str);
                    return;
                }

                File.WriteAllText(logfile, str);
            }
            catch
            {
            }
        }
    }
}
