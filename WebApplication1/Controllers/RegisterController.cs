using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using protocol;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/register")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        [Route("register-start")]
        [HttpPost]
        public RegisterStartAck Post([FromBody] RegisterStartReq requuest)
        {
            RegisterStartAck response = new RegisterStartAck();
            response.id = 100500;
            response.result = RegisterStartAck.Result.OK;
            return response;
        }
    }
}
