using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Bot.DAI.Defaults
{
    public class DefaultMessageSender : IMessageSender
    {
        private readonly string _token;
        private readonly string _version;
        private Random rnd;
        private string _destSystem;

        public DefaultMessageSender(string token, string version, string destSystem)
        {
            _token = token;
            _version = version;
            _destSystem = destSystem;
            rnd = new Random();
        }

        public void Send(string peer_id, string message)
        {
            var reqBuilder = new MessageRequestBuilder(_destSystem);
            reqBuilder.Add("", peer_id);
            reqBuilder.Add("", message);
            reqBuilder.Add("", _version);
            reqBuilder.Add("", _token);
            reqBuilder.Add("", rnd.Next(int.MinValue, int.MaxValue).ToString());

            var request = WebRequest.Create(reqBuilder.Build());

            var response = request.GetResponse();
        }
    }
}
