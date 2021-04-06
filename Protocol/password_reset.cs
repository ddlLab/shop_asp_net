using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace protocol
{
    public class PassResetReq
    {
        public int type { get; set; }
        public string new_pass { get; set; }
    }

    public class PassResetAck
    {
        public enum Result
        {
            SUCCESS_PASS_WAS_CHANGED=0,
            FAIL_OLD_PASS_WAS_PRINTED=-1,
            FAIL_INCORRECT_SYNTAX=-2,
            FAIL_PASSWORD_WASNT_CHANGED=-3
        }
        public int type { get; set; }
        public Result result { get; set; }
    }
}
