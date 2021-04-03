using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using protokol;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/register")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        [Route("register-start")]
        [HttpPost]
        public SetupCardAck Post([FromBody] SetupCardReq request )
        {
            SetupCardAck response = new SetupCardAck();
            response.type = true;
            response.result = SetupCardAck.Result.FAIL;
            return response;
        }
    }
}
