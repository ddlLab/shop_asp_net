using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace protocol
{
    public class RegisterStartReq
    {
        public int     type    { get; set; }
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

        public RegisterStartAck() { }
        public RegisterStartAck(Result _result, int _id = -1)
        {
            result = _result;
            id     = _id;
        }
        public int      id      { get; set; } = -1;
        public Result   result  { get; set; }
    }
    public class RegisterFinishReq
    {
        public int type { get; set; }
        public string code { get; set; }
    }
    public class RegisterFinishAck
    {
		public enum Result
        {
            FAIL = -1,
            OK = 0
        }
        public RegisterFinishAck(Result _result, int _id = -1)
        {
            result = _result;
            user_id = _id;
        }
        public int user_id { get; set; } = -1;
        public Result result { get; set; }
    }

}
