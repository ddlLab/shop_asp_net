using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace protocol
{
    public class UpdateReq
    {
        public string email { get; set; }
        public int type { get; set; }
    }
    public class UpdateAck
    {
        public UpdateAck(Result _result) { result = _result; }
        public enum Result
        {
            FAIL_UNREGISTER_USER = -3,
            FAIL_INCORRECT_EMAIL = -2,
            UNKNOWN_ERROR = -1,
            SUCCESS = 0
        }
        public Result result { get; set; }
    }
    public class ConfUpdateReq
    {
        public int type { get; set; }
        public string code { get; set; }
        public string new_card { get; set; }
    }
    public class ConfUpdateAck
    {
        public ConfUpdateAck(Result result)
        {
            this.result = result;
        }

        public enum Result
        {
            FAIL_UNKNOWN_TYPE   = -3,
            FAIL_INCORRECT_CARD = -2,
            FAIL_INCORRECT_CODE = -1,
            SUCCESS = 0
        }
        public Result result { get; set; }
    }
}
