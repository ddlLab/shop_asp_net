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
        public int user_id { get; set; }
        public string new_pass { get; set; }
    }

    public class PassResetAck
    {
        public enum Result
        {
            FAIL_NEW_PASS_SAME_AS_OLD = -3,
            FAIL_INCORRECT_PASS = -2,
            SUCCESS = 0
        }
        public Result result { get; set; }
    }
}
