using System;

namespace EF
{
    public class CpuLog
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Percentage { get; set; }

        public Guid? SysInfoId { get; set; }
        public SysInfo SysInfo { get; set; }
    }
}