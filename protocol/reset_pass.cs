using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace protocol
{
    public class ResetReq
    {
        public string email { get; set; }
        public int type { get; set; }
    }
    public class ResetAck
    {
      public  ResetAck(Result _result)  { result = _result; }
        public enum Result
        {
            FAIL_UNREGISTER_USER = -3,
            FAIL_INCORRECT_EMAIL = -2,
            UNKNOWN_ERROR = -1,
            SUCCESS = 0
        }     
        public Result result { get; set; }
    }
    public class ConfResetReq
    {
        public int type { get; set; }
        public string code { get; set; }
        public string new_pass { get; set; }
    }
    public class ConfResetAck
    {
        public ConfResetAck(Result result)
        {
            this.result = result;
        }

        public enum Result
        {
            FAIL_NEW_PASS_SAME_AS_OLD = -3,
            FAIL_INCORRECT_PASS = -2,
            FAIL_INCORRECT_CODE = -1,
            SUCCESS = 0
        }
        public Result result { get; set; }
    }
}
