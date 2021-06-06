using System;
using System.Collections.Generic;
using System.Linq;
using protocol;
using db_queries;
using db_queries._2.queries;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace WebApplication1.controls
{
    public class ResetPasswordControl
    {
        protected class ResetRequest
        {
            public ResetReq msg;
            public string   code;
            public DateTime createdTime;
        }
        public ResetPasswordControl()
        {
            requests = new List<ResetRequest>();
        }

        public ResetAck OnResetStart(ResetReq msg)
        {
            if (!IsValidEmail(msg.email))
            {
                return new ResetAck(ResetAck.Result.FAIL_INCORRECT_EMAIL);
            }
            DropExpiredCodes();
            ResetRequest req = GetRequestByEmail(msg.email);
            if (req != null)
            {
                req.createdTime = DateTime.Now;
            }
            else if (!IsUserRegistred(msg))
            {
                return new ResetAck(ResetAck.Result.FAIL_UNREGISTER_USER);
            }
            else
            {
                req = new ResetRequest();
                req.createdTime = DateTime.Now;
                req.code = GenerateCode();
                req.msg = msg;
                requests.Add(req);
            }
            if (req != null)
            {
                try
                {
                    SendCode(req.msg.email, req.code);
                }
                catch
                {
                    return new ResetAck(ResetAck.Result.FAIL_INCORRECT_EMAIL);
                }
                return new ResetAck(ResetAck.Result.SUCCESS);
            }
            return new ResetAck(ResetAck.Result.UNKNOWN_ERROR);
        }
        public ConfResetAck OnResetFinish(ConfResetReq msg)
        {
            if (msg.type != 0 && msg.type != 1)
            {
                return new ConfResetAck(ConfResetAck.Result.FAIL_UNKNOWN_TYPE);
            }
            if (msg.new_pass.Length < 8)
            {
                return new ConfResetAck(ConfResetAck.Result.FAIL_INCORRECT_PASS);
            }
            DropExpiredCodes();
            ResetRequest request = null;
            foreach (ResetRequest req in requests)
            {
                if (msg.code.Equals (req.code) && msg.type == req.msg.type )
                {
                    request = req;
                    break;
                }
            }
            if (request == null)
            {
                return new ConfResetAck(ConfResetAck.Result.FAIL_INCORRECT_CODE);
            }
            QueryBase query = null;
            if (msg.type == 0)
            {
                query = new QueryUpdateClientPass(request.msg.email, msg.new_pass, DBUtils.GetDBConnection(), null);
            }
            else
            {
                query = new QueryUpdateSalerPass(request.msg.email, msg.new_pass, DBUtils.GetDBConnection(), null);
            }
            query.Execute();
            requests.Remove(request);
            return new ConfResetAck(ConfResetAck.Result.SUCCESS);
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
            m.Subject = "Restore password Code";
            m.Body = $"Setup this code to confirm password reset. Your Code is {code}";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("rerolld100@gmail.com", "ddeasumakdsinanv");
            smtp.EnableSsl = true;
            smtp.SendMailAsync(m);
        }

        static readonly int expirationTimeSec = 15 * 60;
        protected void DropExpiredCodes()
        {
            DateTime currentTime = DateTime.Now;
            requests.RemoveAll(req =>
            {
                long elapsedTicks = currentTime.Ticks - req.createdTime.Ticks;
                TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
                return elapsedSpan.TotalSeconds > expirationTimeSec;
            });
        }

        static readonly string alphabet = "1234567890qwertyuiopasdfghjklzxcvbnmPOIUYTREWQLKJHGFDSAMNBVCXZ";
        static Random random = new Random();
        protected string GenerateCode(int size = 6)
        {
            string code = "";
            for (int i = 0; i < size; ++i)
            {
                code += alphabet[random.Next(0, alphabet.Length)];
            }
            if (HasCode(code))
            {
                return GenerateCode();
            }
            return code;
        }
        List<ResetRequest> requests = null;
        protected bool IsUserRegistred(ResetReq msg)
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

        protected bool HasCode(string code)
        {
            var req = requests.Find(req => { return req.msg.email == code; });

            return req != null;
        }
        protected ResetRequest GetRequestByEmail(string email)
        {
            return requests.Find(req =>
            {
                return req.msg.email == email;
            });
        }
    }
}
