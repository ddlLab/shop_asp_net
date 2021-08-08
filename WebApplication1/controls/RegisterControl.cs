using protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using db_queries;
using db_queries._2.queries;
using System.Net.Mail;
using System.Net;

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
                requests.Add(req);
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
            DropExpiredCodes();
            StartRequest request = null;
            foreach ( StartRequest startRequest in requests)
            {
                if (msg.code == startRequest.code)
                {
                    request = startRequest;
                    break;
                }
            }
            if(request == null)
            {
                return new RegisterFinishAck(RegisterFinishAck.Result.FAIL);
            }
            QueryBase query = null;
            if (msg.type == 0)
            {
                query = new QueryInsertClient(ConverterUser.MakeClient(request.msg),
                                              DBUtils.GetDBConnection(),
                                              null);
            }
            else if (msg.type == 1)
            {
                query = new QueryInsertSaler(ConverterUser.MakeSaler(request.msg),
                                             DBUtils.GetDBConnection(),
                                             null);
            }
            query.Execute();
            requests.Remove(request);
            return new RegisterFinishAck(RegisterFinishAck.Result.OK, (int) getIDbyMail(request.msg.email, msg.type));
        }

        long getIDbyMail(string email, int type)
        {
            if (type == 0)
            {
                QuerySelectClientByEmailNick query = new QuerySelectClientByEmailNick("",
                                                                                      email,
                                                                                      DBUtils.GetDBConnection(),
                                                                                      null);
                query.Execute();
                return query.clients[0].Id;
            }
            else
            {
                QuerySelectSalerByEmailNick query = new QuerySelectSalerByEmailNick("",
                                                                                    email,
                                                                                    DBUtils.GetDBConnection(),
                                                                                    null);
                query.Execute();
                return query.salers[0].Id;
            }
        }
        protected bool IsUserRegistred(RegisterStartReq msg)
        {
            if (msg.type == 0)
            {
                QuerySelectClientByEmailNick query = new QuerySelectClientByEmailNick("",
                                                                                      msg.email,
                                                                                      DBUtils.GetDBConnection(),
                                                                                      null);
                query.Execute();
                return query.clients.Count != 0;
            }
            else
            {
                QuerySelectSalerByEmailNick query = new QuerySelectSalerByEmailNick("",
                                                                                    msg.email,
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
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        protected void SendCode(string email, string code)
        {
            MailAddress from = new MailAddress("rerolld100@gmail.com", "Dmytro&SashkoShop");
            MailAddress to = new MailAddress(email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Registratition Code";
            m.Body = $"Setup this code to confirm registration. Your Code is {code}";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("rerolld100@gmail.com", "ddeasumakdsinanv");
            smtp.EnableSsl = true;
            smtp.SendMailAsync(m);
        }

        List<StartRequest> requests = null;
    }
}
