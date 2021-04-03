using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace protocol
{
    public class RegisterStartReq
    {
        public bool    type    { get; set; }
        public string  email   { get; set; }
        public string  pass    { get; set; }
        public string  nick    { get; set; }
    }

    public class RegisterStartAck
    {
        public enum Result
        {
            EMAIL_NOT_FOUND     = -4,
            BAD_REQUEST         = -3,
            NON_UNIQUE_EMAIL    = -2,
            NON_UNIQUE_NICKNAME = -1,
            OK                  = 0
        }
        public int      id      { get; set; } = -1;
        public Result   result  { get; set; }
    }
    public class RegisterFinishReq
    {
        public bool type { get; set; }
        public string code { get; set; }
    }
    public class RegisterFinishAck
    {
		public enum Result
        {
            FAIL = -1,
            OK = 0
        }
        public int user_id { get; set; }
        public Result result { get; set; }
    }
    public class LoginReq
    {
        public bool type { get; set; }
        public string email { get; set; }
        public string pass { get; set; }
    }
    public class LoginAck
    {
		public enum Result
        {
            FAIL_INVALID_PASS = -2,
            FAIL_EMAIL_NOT_FOUND = -1,
            SUCCESS = 0
        }
        public int user_id { get; set; }// = RegisterStartAck.id;        
        public Result result { get; set; }
    }
    public class SetupCardReq
    {
        public bool type { get; set; }
        public int user_id { get; set; }
        public string card { get; set; }
    }
    public class SetupCardAck
    {
	    public enum Result
        {
            FAIL = -1,
            OK = 0
        }
        public bool type { get; set; }
        public Result result { get; set; }
    }

}
