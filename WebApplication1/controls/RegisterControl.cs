using protocol;
using testproj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using db_queries;
using db_queries._2.queries;

namespace WebApplication1.controls
{
    public class RegisterControl
    {
        protected class StartRequest
        {
            public RegisterStartReq msg;
            public string           code;
            public DateTime         createdTime;
        }
        public RegisterControl()
        {
            requests = new List<StartRequest>();
        }

        public RegisterStartAck OnRegisterStart(RegisterStartReq msg)
        {
            if(!IsValidEmail(msg.email))
            {
                return new RegisterStartAck(RegisterStartAck.Result.EMAIL_NOT_FOUND);
            }
            DropExpiredCodes();
            StartRequest req = GetRequestByEmail(msg.email);
            if(req != null)
            {
                req.createdTime = DateTime.Now;
            }
            else if(!IsUserRegistred(msg))
            {
                req             = new StartRequest();
                req.msg         = msg;
                req.createdTime = DateTime.Now;
                req.code        = GenerateCode();
            }
            if(req != null)
            {
                try 
                {
                    SendCode(req.msg.email, req.code);
                }
                catch
                {
                    return new RegisterStartAck(RegisterStartAck.Result.BAD_REQUEST);
                }
                return new RegisterStartAck(RegisterStartAck.Result.OK);
            }
            return new RegisterStartAck(RegisterStartAck.Result.NON_UNIQUE_EMAIL);
        }
        public RegisterFinishAck OnRegisterFinish(RegisterFinishReq msg)
        {
            //todo alex
            //Drop all Expired requests
            //Find Requst start with same code(maybe has in this class method?)
            // if code not found return Finish Ack with error
            // otherwise convert req.msg to object class Saler|Client
            // Call insert query and exec it (see db_query proj)
            // return Success Finish Ack
            DropExpiredCodes();
            if (msg != req.code)
                return new RegisterFinishAck(RegisterFinishAck.Result.FAIL);
            {                 
                if (msg.type == 0)
                {
                    Saler[eUser.id] = new eUser;
                }
                else if (msg.type == 1)
                {
                    Client[eUser.id] = new eUser;
                }
            }
            QueryBase.Execute();
            return new RegisterFinishAck(RegisterFinishAck.Result.OK);
        }
        protected bool IsUserRegistred(RegisterStartReq msg)
        {
            if(msg.type == 0)
            {
                QuerySelectClientByEmailNick query = new QuerySelectClientByEmailNick(msg.email,
                                                                                      msg.nick,
                                                                                      DBUtils.GetDBConnection(),
                                                                                      null);
                query.Execute();
                return query.clients.Count != 0;
            }
            else
            {
                QuerySelectSalerByEmailNick query = new QuerySelectSalerByEmailNick(msg.email,
                                                                                    msg.nick,
                                                                                    DBUtils.GetDBConnection(),
                                                                                    null);
                query.Execute();
                return query.salers.Count != 0;
            }
        }
        static readonly string alphabet = "1234567890qwertyuiopasdfghjklzxcvbnmPOIUYTREWQLKJHGFDSAMNBVCXZ";
        static Random random = new Random();
        protected string GenerateCode(int size = 6)
        {
            string code = "";
            for(int i = 0; i < size; ++i)
            {
                code += alphabet[random.Next(0, alphabet.Length)];
            }
            if(HasCode(code))
            {
                return GenerateCode();
            }
            return code;
        }

        static readonly int expirationTimeSec = 15 * 60;
        protected void DropExpiredCodes()
        {
            DateTime currentTime = DateTime.Now;
            requests.RemoveAll(req=>
            {
                long elapsedTicks = currentTime.Ticks - req.createdTime.Ticks;
                TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
                return elapsedSpan.TotalSeconds > expirationTimeSec;
            });
        }

        protected bool HasCode(string code)
        {
            var req = requests.Find(req => { return req.msg.email == code; });

            return req != null;
        }
        protected StartRequest GetRequestByEmail(string email)
        {
            return requests.Find(req =>
            {
                return req.msg.email == email;
            });
        }
        protected bool IsValidEmail(string email)
        {
            //todo dmitro
            //1 - @
            //before after @ has symbols
            // minimum 1 dot
            // dot must be after @ 
            //between dot and @ must bee symbols
            // after dot must bee symbols

            
            return false;
        }

        protected void SendCode(string email, string code)
        {
            //todo dmitro || alex
            //https://metanit.com/sharp/net/8.1.php
        }

        List<StartRequest> requests = null;
    }
}
