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
}
