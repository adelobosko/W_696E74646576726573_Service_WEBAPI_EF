using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    class SysInfoContext : DbContext
    {
        public SysInfoContext()
            : base("SysInfoDB")
        { }

        public DbSet<SysInfo> SysInfos { get; set; }
    }
}
