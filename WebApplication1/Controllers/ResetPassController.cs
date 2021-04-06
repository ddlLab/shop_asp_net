using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using protocol;

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
            ResetAck response = new ResetAck();
            response.result = ResetAck.Result.SUCCESS;
            return response;
        }

        [Route("reset-finish")]
        [HttpPost]
        public ConfResetAck Post([FromBody] ConfResetReq request)
        {
            ConfResetAck response = new ConfResetAck();
            response.result = ConfResetAck.Result.SUCCESS;
            return response;
        }
    }
}
