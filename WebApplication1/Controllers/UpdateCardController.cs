using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using protocol;
using WebApplication1.controls;

namespace WebApplication1.Controllers
{
    [Route("api/paycard")]
    [ApiController]
    public class UpdateCardController
    {
        [Route("update-start")]
        [HttpPost]
        public UpdateAck Post([FromBody] UpdateReq request)
        {
            return eEngine.GetUpdateCardControl().OnUpdateStart(request);
        }

        [Route("update-finish")]
        [HttpPost]
        public ConfUpdateAck Post([FromBody] ConfUpdateReq request)
        {
            return eEngine.GetUpdateCardControl().OnUpdateFinish(request);
        }
    }
}
