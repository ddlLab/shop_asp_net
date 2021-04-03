using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace protocol
{
    public class SetupCardReq
    {
        public int type { get; set; }
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
        public int type { get; set; }
        public Result result { get; set; }
    }
}
