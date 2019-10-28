using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    [Serializable]
    public class SysInfoDM
    {
        public Guid Id { get; set; }
        public string PCName { get; set; }
        public string Manufacturer { get; set; }
        public double RAMLoad { get; set; }
        public DateTime DateTimeLog { get; set; }


        public ICollection<CpuLogDM> CPULogs { get; set; }
        public ICollection<LoggedUsersLogDM> LoggedUsersLogs { get; set; }

        public SysInfoDM()
        {
            CPULogs = new List<CpuLogDM>();
            LoggedUsersLogs = new List<LoggedUsersLogDM>();
        }

    }
}
