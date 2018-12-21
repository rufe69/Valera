using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Valera_bot
{
    public class Bot
    {
        public void SendMessage(string peer_id,string message)
        {
            var token = Environment.GetEnvironmentVariable("ACCESS_TOKEN");
            var version = Environment.GetEnvironmentVariable("VERSION");
            var random_id = new Random().Next(int.MinValue,int.MaxValue);
            WebRequest req = WebRequest.Create($"https://api.vk.com/method/messages.send?" +
                                                                                 $"peer_id={peer_id}&" +
                                                                                 $"message={message}&" +
                                                                                 $"random_id={random_id}&" +
                                                                                 $"v={version}&" +
                                                                                 $"access_token={token}");
            WebResponse resp = req.GetResponse();
        }
    }
}
