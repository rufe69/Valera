using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Valera_bot.Controllers
{
    [Produces("application/json")]
    [Route("api/Test")]
    public class TestController : Controller
    {

        [HttpGet]
        public string Get()
        {
            Schedule sc = new Schedule();
            var res = sc.AllSchedule();

            return res;
        }
    }
}
