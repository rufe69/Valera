using System;
using System.Collections.Generic;
using System.IO;
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

        async public void Send(string peer_id, string message)
        {
            var reqBuilder = new MessageRequestBuilder();
            reqBuilder.Add("peer_id", peer_id);
            reqBuilder.Add("message", message);
            reqBuilder.Add("random_id", rnd.Next(int.MinValue, int.MaxValue).ToString());

            reqBuilder.Add("v", _version);
            reqBuilder.Add("access_token", _token);

            var request = WebRequest.Create(_destSystem);
            request.Method = "POST";

            byte[] byteArray = Encoding.UTF8.GetBytes(reqBuilder.Build());
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            using (Stream dataStream = await request.GetRequestStreamAsync())
                await dataStream.WriteAsync(byteArray, 0, byteArray.Length);

            var response = await request.GetResponseAsync();
            response.Close();
        }
    }
}
