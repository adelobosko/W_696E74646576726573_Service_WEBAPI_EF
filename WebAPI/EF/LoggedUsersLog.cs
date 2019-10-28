using System;

namespace WebAPI.EF
{
    public class LoggedUsersLog
    {
        public Guid Id { get; set; }
        public  string Name { get; set; }

        public Guid? SysInfoId { get; set; }
        public SysInfo SysInfo { get; set; }
    }
}