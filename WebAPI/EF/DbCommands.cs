using System;

namespace WebAPI.EF
{
    public static class DbCommands
    {
        public static bool PutSysInfo(SysInfo sysInfo)
        {
            try
            {
                var sysInfoContext = new SysInfoContext();
                sysInfoContext.SysInfos.Add(sysInfo);
                sysInfoContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
    }
}
