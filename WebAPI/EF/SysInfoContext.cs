using Microsoft.EntityFrameworkCore;

namespace WebAPI.EF
{
    internal class SysInfoContext : DbContext
    {
        public SysInfoContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SysInfoDB;Trusted_Connection=True;");
        }

        public DbSet<SysInfo> SysInfos { get; set; }
        public DbSet<CpuLog> CpuLogs { get; set; }
        public DbSet<LoggedUsersLog> LoggedUsersLogs{ get; set; }
    }
}
