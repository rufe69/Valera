using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bot.DAI;
using Microsoft.AspNetCore.Http;
using System.IO;
using Newtonsoft.Json;
using Bot.API;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Message")]
    public class MessageController : Controller
    {
        private readonly IMessageSender _messageSender;

        public MessageController(IMessageSender messageSender)
        {
            _messageSender = messageSender;
        }

        [HttpPost]
        public async void Post()
        {
            var reader = new StreamReader(HttpContext.Request.Body);
            var text = await reader.ReadToEndAsync();

            var callbackEvent = JsonConvert.DeserializeObject<CallbackEvent>(text);
            Schedule sc = new Schedule();

            if (text.ToLower().Contains("/"))
            {
                var commands = new Commands();
                _messageSender.Send(callbackEvent.Object.Peer_id, commands.ConvertMessage(callbackEvent.Object.Text));
                await Response.WriteAsync("ok");
                return;
            }


            _messageSender.Send(callbackEvent.Object.Peer_id, callbackEvent.Object.Text);

            await Response.WriteAsync("ok");
        }
    }
}