using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using protocol;
using WebApplication1.controls;

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
            return eEngine.GetRegisterControl().OnRegisterStart(request);
        }

        [Route("register-finish")]
        [HttpPost]
        public RegisterFinishAck Post([FromBody] RegisterFinishReq request)
        {
            return eEngine.GetRegisterControl().OnRegisterFinish(request);
        }
    }
}
