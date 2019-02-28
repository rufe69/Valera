using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bot.DAI;
using Microsoft.AspNetCore.Http;
using System.IO;
using Newtonsoft.Json;
using Bot.Schedule;
using Bot.Commands;

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
            await Response.WriteAsync("ok");

            var reader = new StreamReader(HttpContext.Request.Body);
            var text = await reader.ReadToEndAsync();

            var callbackEvent = JsonConvert.DeserializeObject<CallbackEvent>(text);

            var requester = callbackEvent.Object.From_id;
            var conversation = callbackEvent.Object.Peer_id;
            var message = callbackEvent.Object.Text;

            var schedule = new ScheduleModule();
            var responseMessage = schedule.Convert(callbackEvent.Object.Text);


            _messageSender.Send(callbackEvent.Object.Peer_id, responseMessage);
        }
    }
}