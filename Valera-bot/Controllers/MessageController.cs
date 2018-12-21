using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Valera_bot.Models;

namespace Valera_bot.Controllers
{
    [Produces("application/json")]
    [Route("api/Message")]
    public class MessageController : Controller
    {
        Bot bot;

        [HttpPost]
        public async void Post()
        {
            bot = new Bot();

            StreamReader reader = new StreamReader(HttpContext.Request.Body);
            string text = await reader.ReadToEndAsync();

            CallbackEvent callbackEvent = (CallbackEvent) JsonConvert.DeserializeObject(text, typeof(CallbackEvent));
            Schedule sc = new Schedule();

            if (text.ToLower().Contains("/"))
            {
                var commands = new Commands();
                bot.SendMessage(callbackEvent.Object.Peer_id, commands.ConvertMessage(callbackEvent.Object.Text));
                await Response.WriteAsync("ok");
                return;
            }


            bot.SendMessage(callbackEvent.Object.Peer_id, sc.ConvertMessage(callbackEvent.Object.Text));

            await Response.WriteAsync("ok");
        }
    }
}
