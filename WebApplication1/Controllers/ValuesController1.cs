using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public struct TestReq
    {
        public string Name { set; get; }
        public string Password { set; get; }
    }
    public struct TestAck
    {
        public TestReq Result { set; get; }
        public string state { set; get; }
    }
    [Route("api/Igor")]
    [ApiController]
    public class ValuesController1 : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Angliyskie", "Varyagzskie" };
        }
        [Route("id")]
        [HttpGet]
        public string Get(int id)
        {
            return "Nice";
        }
        [Route("post")]
        [HttpPost]
        public TestAck Post([FromBody] TestReq request)
        {   if (random == null)
            {
                random = new Random();
            }
            TestAck response = new TestAck();
            response.Result = request;
            string[] states = { "AAAA", "Dich", "Pain", "Shaitan" };
            response.state = states[random.Next() % 4];
            return response;    
        }
        static Random random = null;
    }
}
