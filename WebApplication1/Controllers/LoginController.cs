using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using protocol;

namespace WebApplication1.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [Route("login")]
        [HttpPost]
        public LoginAck Post([FromBody] LoginReq login)
        {
            LoginAck response = new LoginAck();
            response.user_id = 1;
            response.result = LoginAck.Result.SUCCESS;
            return response;
        }
    }
}
