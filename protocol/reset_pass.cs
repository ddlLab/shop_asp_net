using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace protocol
{
    public class ResetReq
    {
        public string name { get; set; }
        public int type { get; set; }
    }
    public class ResetAck
    {
        public enum Result
        {
            FAIL_INCORRECT_EMAIL = -2,
            FAIL_INCORRECT_NAME = -1,
            SUCCESS = 0
        }     
        public string confirm_message { get; set; }
        public Result result { get; set; }
    }
    public class ConfResetReq
    {
        public string confirm_message { get; set; }
        public string new_pass { get; set; }
    }
    public class ConfResetAck
    {
        public enum Result
        {
            FAIL_NEW_PASS_SAME_AS_OLD = -3,
            FAIL_INCORRECT_PASS = -2,
            FAIL_INCORRECT_CONF_MESSAGE = -1,
            SUCCESS = 0
        }
        public Result result { get; set; }
    }
}
