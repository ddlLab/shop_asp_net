using db_queries._3.structures;
using protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.controls
{
    class eClientOnline
    {
        public eClientOnline(eClient _client)
        {
            client_ = _client;
        }
        public eClient  client_    = null;
        public DateTime lastAction_ = DateTime.Now;
    }
    class eSalerOnline
    {
        public eSalerOnline(eSaler _saler)
        {
            saler_ = _saler;
        }
        public eSaler   saler_ = null;
        public DateTime lastAction_ = DateTime.Now;
    }
    class LoginControl
    {
        static readonly long TIMEOUT_WITHOUT_ACTIONS = 30 * 60;
        static readonly long TIMEOUT_UPDATE = 1 * 60;
        DateTime lastUpdate;
        public LoginControl()
        {
            onlineClients = new Dictionary<long, eClientOnline>();
            onlineSalers = new Dictionary<long, eSalerOnline>();
            lastUpdate = DateTime.Now;
        }

        public void Update()
        {
            long elapsedTicks = DateTime.Now.Ticks - lastUpdate.Ticks;
            TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
            if(elapsedSpan.TotalSeconds > TIMEOUT_UPDATE)
            {
                DropByTimeout();
                lastUpdate = DateTime.Now;
            }
        }
        protected void DropByTimeout()
        {
            DateTime currentTime = DateTime.Now;
            var toRemoveClients = onlineClients.Where(pair =>
            {
                 long elapsedTicks = currentTime.Ticks - pair.Value.lastAction_.Ticks;
                 TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
                 return elapsedSpan.TotalSeconds > TIMEOUT_WITHOUT_ACTIONS;
            }).Select(pair => pair.Key).ToList();
            
            var toRemoveSalers = onlineSalers.Where(pair =>
            {
                long elapsedTicks = currentTime.Ticks - pair.Value.lastAction_.Ticks;
                TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
                return elapsedSpan.TotalSeconds > TIMEOUT_WITHOUT_ACTIONS;
            }).Select(pair => pair.Key).ToList();

            foreach (var key in toRemoveClients)
            {
                onlineClients.Remove(key);
            }
            foreach (var key in toRemoveSalers)
            {
                onlineSalers.Remove(key);
            }
        }

        LoginAck OnLoginSaler(LoginReq msg)
        {
            var response = new LoginAck();
            eSaler saler = LoadSaler(msg.email);
            if (saler == null)
            {
                return response;
            }
            if (saler.Password == msg.pass)
            {
                response.result = LoginAck.Result.SUCCESS;
                response.user_id = saler.Id;
                onlineSalers.Add(saler.Id, new eSalerOnline(saler));
                return response;
            }
            response.result = LoginAck.Result.FAIL_INVALID_PASS;
            return response;
        }
        LoginAck OnLoginClient(LoginReq msg)
        {
            var response = new LoginAck();
            eClient client = LoadClient(msg.email);
            if (client == null)
            {
                return response;
            }
            if (client.Password == msg.pass)
            {
                response.result = LoginAck.Result.SUCCESS;
                response.user_id = client.Id;
                onlineClients.Add(client.Id, new eClientOnline(client));
                return response;
            }
            response.result = LoginAck.Result.FAIL_INVALID_PASS;
            return response;
        }
        public LoginAck OnLogin(LoginReq msg)
        {
            LoginAck response = null;
            if(msg.type == 0)
            {
                response = OnLoginClient(msg);
            }
            if (msg.type == 1)
            {
                response = OnLoginSaler(msg);
            }
            return new LoginAck();
        }

        public Dictionary<long, eClientOnline> onlineClients = null;
        public Dictionary<long, eSalerOnline> onlineSalers = null;
    }
}
