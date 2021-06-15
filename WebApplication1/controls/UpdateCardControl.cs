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
    public class UpdateCardControl
    {
        protected class UpdateRequest
        {
            public UpdateReq msg;
            public string code;
            public DateTime createdTime;
        }
        public UpdateCardControl()
        {
            requests = new List<UpdateRequest>();
        }

        public UpdateAck OnUpdateStart(UpdateReq msg)
        {
            if (!IsValidEmail(msg.email))
            {
                return new UpdateAck(UpdateAck.Result.FAIL_INCORRECT_EMAIL);
            }
            DropExpiredCodes();
            UpdateRequest req = GetRequestByEmail(msg.email);
            if (req != null)
            {
                req.createdTime = DateTime.Now;
            }
            else if (!IsUserRegistred(msg))
            {
                return new UpdateAck(UpdateAck.Result.FAIL_UNREGISTER_USER);
            }
            else
            {
                req = new UpdateRequest();
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
                    return new UpdateAck(UpdateAck.Result.FAIL_INCORRECT_EMAIL);
                }
                return new UpdateAck(UpdateAck.Result.SUCCESS);
            }
            return new UpdateAck(UpdateAck.Result.UNKNOWN_ERROR);
        }
        public ConfUpdateAck OnUpdateFinish(ConfUpdateReq msg)
        {
            if (msg.type != 0 && msg.type != 1)
            {
                return new ConfUpdateAck(ConfUpdateAck.Result.FAIL_UNKNOWN_TYPE);
            }
            if (msg.new_card.Length < 16)
            {
                return new ConfUpdateAck(ConfUpdateAck.Result.FAIL_INCORRECT_CARD);
            }
            DropExpiredCodes();
            UpdateRequest request = null;
            foreach (UpdateRequest req in requests)
            {
                if (msg.code.Equals(req.code) && msg.type == req.msg.type)
                {
                    request = req;
                    break;
                }
            }
            if (request == null)
            {
                return new ConfUpdateAck(ConfUpdateAck.Result.FAIL_INCORRECT_CODE);
            }
            QueryBase query = null;
            if (msg.type == 0)
            {
                query = new QueryUpdateClientCard(request.msg.email, msg.new_card, DBUtils.GetDBConnection(), null);
            }
            else
            {
                query = new QueryUpdateSalerCard(request.msg.email, msg.new_card, DBUtils.GetDBConnection(), null);
            }
            query.Execute();
            requests.Remove(request);
            return new ConfUpdateAck(ConfUpdateAck.Result.SUCCESS);
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
            m.Subject = "Update paycard Code";
            m.Body = $"Setup this code to confirm paycard update. Your Code is {code}";
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
        List<UpdateRequest> requests = null;
        protected bool IsUserRegistred(UpdateReq msg)
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
        protected UpdateRequest GetRequestByEmail(string email)
        {
            return requests.Find(req =>
            {
                return req.msg.email == email;
            });
        }
    }
}
