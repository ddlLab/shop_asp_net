using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using protocol;
using WebApplication1.controls;

namespace WebApplication1.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [Route("login")]
        [HttpPost]
        public LoginAck Post([FromBody] LoginReq msg)
        {
            return eEngine.GetLoginControl().OnLogin(msg);
        }
    }
}
