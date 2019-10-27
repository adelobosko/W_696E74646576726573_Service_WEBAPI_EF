using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{/*
            str += $"\r\n{GetUsers().Aggregate((i, j) => $"{i}, {j}")}";
            str += $"\r\n{GetCPULoad().Select(cpu => $"{cpu.Item1}: {cpu.Item2}%").Aggregate((i, j) => $"{i}, {j}")}";
            str += $"\r\n{GetRAMLoad()}";
            str += $"\r\n{DateTime.Now.ToString()}";
            File.WriteAllText("E:\\res.txt", str);
            */
    public class SysInfo
    {
        public Guid Id { get; set; }
        public string PCName { get; set; }
        public string Manufacturer { get; set; }


        public ICollection<CPULog> CPULogs { get; set; }

        public SysInfo()
        {
            CPULogs = new List<CPULog>();
        }

    }

    public class ActiveUsersLog
    {
        public Guid Id { get; set; }
        public  string Name { get; set; }
    }

    public class CPULog
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Percentage { get; set; }

        public Guid? SysInfoId { get; set; }
        public SysInfo SysInfo { get; set; }
    }

    class SysInfoContext : DbContext
    {
        public SysInfoContext()
            : base("SysInfoDB")
        { }

        public DbSet<SysInfo> SysInfos { get; set; }
    }
}
