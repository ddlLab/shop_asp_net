using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using protocol;

namespace WebApplication1.Controllers
{
    [Route("api/register")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        [Route("register-start")]
        [HttpPost]
        public RegisterStartAck Post([FromBody] RegisterStartReq request)
        {
            RegisterStartAck response = new RegisterStartAck();
            response.id = 100500;
            response.result = RegisterStartAck.Result.OK;
            return response;
        }

        [Route("register-finish")]
        [HttpPost]
        public RegisterFinishAck Post([FromBody] RegisterFinishReq request)
        {
            RegisterFinishAck response = new RegisterFinishAck();
            response.user_id = 42;
            response.result = RegisterFinishAck.Result.FAIL;
            return response;
        }
    }
}
