using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace protocol
{
    public class LoginReq
    {
        public int type { get; set; }
        public string email { get; set; }
        public string pass { get; set; }
    }
    public class LoginAck
    {
        public LoginAck()
        {
            result = Result.FAIL_EMAIL_NOT_FOUND;
        }
        public enum Result
        {
            FAIL_INVALID_PASS = -2,
            FAIL_EMAIL_NOT_FOUND = -1,
            SUCCESS = 0
        }
        public long user_id { get; set; } = -1;
        public Result result 
        {
            get;
            set; 
        }
       // public string resultDesc { get; set; } = "";
    }
}
