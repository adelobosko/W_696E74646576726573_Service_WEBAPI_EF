using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EF;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SysInfoController : ControllerBase
    {
        // GET api/SysInfo
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/SysInfo/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/SysInfo
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/SysInfo/5
        [HttpPut("{pcname}")]
        public void Put(string pcname, [FromBody] SysInfo sysInfo)
        {
        }

        // DELETE api/SysInfo/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
