using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using protocol;

namespace WebApplication1.Controllers
{
    [Route("api/user-settings-cotroller")]
    [ApiController]
    public class UserSettingsController : ControllerBase
    {
        [Route("setupcard")]
        [HttpPost]
        public SetupCardAck Post([FromBody] SetupCardReq request)
        {
            SetupCardAck response = new SetupCardAck();
            response.type = 1;
            response.result = SetupCardAck.Result.OK;
            return response;          
        }

    }
}
