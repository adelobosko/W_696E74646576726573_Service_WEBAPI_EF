using System;
using System.Collections.Generic;

namespace WebAPI.EF
{
    public class SysInfo
    {
        public Guid Id { get; set; }
        public string PCName { get; set; }
        public string Manufacturer { get; set; }
        public double RAMLoad { get; set; }
        public DateTime DateTimeLog { get; set; }


        public ICollection<CpuLog> CPULogs { get; set; }
        public ICollection<LoggedUsersLog> LoggedUsersLogs { get; set; }

        public SysInfo()
        {
            CPULogs = new List<CpuLog>();
            LoggedUsersLogs = new List<LoggedUsersLog>();
        }

    }
}