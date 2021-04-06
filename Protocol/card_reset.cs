using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace protocol
{
    public class SetupNewCardReq
    {
        public int type { get; set; }
        public int user_id { get; set; }
        public string new_card { get; set; }
    }
    public class SetupNewCardAck
    {
        public enum Result
        {
            FAIL_CARD_WAS_REGISTRED_OTHER_USER = -3,
            FAIL_INVALID_CARD = -2,
            FAIL_CARD_NOT_FOUND = -1,
            SUCCESS_CARD_WAS_CHANGED = 0
        }
        public int type { get; set; }
        public Result result { get; set; }
    }
}
