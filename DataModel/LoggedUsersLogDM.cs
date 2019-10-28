using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    [Serializable]
    public class LoggedUsersLogDM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
