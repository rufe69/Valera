using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Bot.DAI;
using Microsoft.AspNetCore.Http;
using System.IO;
using Newtonsoft.Json;

namespace API.Controllers
{
	[Produces("application/json")]
    [Route("api/Message")]
    public class MessageController : Controller
    {
        private readonly IMessageSender _messageSender;
		private readonly IEnumerable<IModule> _modules;

        public MessageController(IMessageSender messageSender, IEnumerable<IModule> modules)
        {
            _messageSender = messageSender;
			_modules = modules;
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
			var message = callbackEvent.Object.Text + " ";

			var responseMessage = "Я тебя не понял";
			if (_modules.Count() == 0)
				responseMessage = "Прости, но сейчас я недоступен(";
			else
				foreach (var module in _modules)
				{
					try
					{
						if (module.Contains(message))
						{
							responseMessage = module.Convert(message);
							break;
						}
					}
					catch (Exception ex)
					{
						ErrorConsole.WriteLine($"({module}) Internal Module Error: {ex.Message}");
						responseMessage = "Произошла ошибка!";
						break;
					}
				}

			_messageSender.Send(callbackEvent.Object.Peer_id, responseMessage);
		}
    }
}