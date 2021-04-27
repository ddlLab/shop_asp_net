using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using db_queries;
using db_queries._3.structures;
using protocol;

namespace WebApplication1
{
    public class ConverterUser
    {
        public static eClient MakeClient(RegisterStartReq msg)
        {
            eClient client  = new eClient();
            client.Password = msg.pass;
            client.Nickname = msg.nick;
            client.Email    = msg.email;
            return client;
        }
        public static eSaler MakeSaler(RegisterStartReq msg)
        {
            eSaler saler= new eSaler();
            saler.Password = msg.pass;
            saler.Nickname = msg.nick;
            saler.Email = msg.email;
            return saler;
        }
    }
}
