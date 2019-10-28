using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using WebAPI.EF;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SysInfoController : ControllerBase
    {
        [HttpPut]
        public void Put([FromBody] SysInfoDM sysInfoDM)
        {
            var res = DbCommands.PutSysInfo(WorkHelper.DataModelToEFModel(sysInfoDM));
        }
    }
}
