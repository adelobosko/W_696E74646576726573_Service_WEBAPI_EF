using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel;
using WebAPI.EF;

namespace WebAPI
{
    public static class WorkHelper
    {
        public static SysInfo DataModelToEFModel(SysInfoDM sysInfoDM)
        {
            var sysInfo = new SysInfo()
            {
                Id = Guid.NewGuid(),
                PCName = sysInfoDM.PCName,
                Manufacturer = sysInfoDM.Manufacturer,
                RAMLoad = sysInfoDM.RAMLoad,
                DateTimeLog = sysInfoDM.DateTimeLog,
                CPULogs = new List<CpuLog>(),
                LoggedUsersLogs = new List<LoggedUsersLog>()
            };

            foreach (var cpuLog in sysInfoDM.CPULogs)
            {
                sysInfo.CPULogs.Add(new CpuLog()
                {
                    Id = Guid.NewGuid(),
                    Name = cpuLog.Name,
                    Percentage = cpuLog.Percentage,
                    SysInfoId = sysInfo.Id,
                    SysInfo = sysInfo
                });
            }

            foreach (var loggedUsersLog in sysInfoDM.LoggedUsersLogs)
            {
                sysInfo.LoggedUsersLogs.Add(new LoggedUsersLog()
                {
                    Id = Guid.NewGuid(),
                    Name = loggedUsersLog.Name,
                    SysInfoId = sysInfo.Id,
                    SysInfo = sysInfo
                });
            }

            return sysInfo;
        }
    }
}
