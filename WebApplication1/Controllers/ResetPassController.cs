using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using protocol;
using WebApplication1.controls;

namespace WebApplication1.Controllers
{
    [Route("api/password")]
    [ApiController]
    public class ResetPassController
    {
        [Route("reset-start")]
        [HttpPost]
        public ResetAck Post([FromBody] ResetReq request)
        {
            return eEngine.GetResetPasswordControl().OnResetStart(request);
        }

        [Route("reset-finish")]
        [HttpPost]
        public ConfResetAck Post([FromBody] ConfResetReq request)
        {
            return eEngine.GetResetPasswordControl().OnResetFinish(request);
        }
    }
}
