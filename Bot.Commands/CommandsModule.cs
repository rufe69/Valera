using Bot.DAI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.Commands
{
	class CommandsModule : IModule
	{
		public bool Contains(string message)
		{
			if (message.Contains("/")) return true;
			return false;
		}

		public string Convert(string text)
		{
			if (text.Contains("/help")) return GetHelp();
			if (text.Contains("/secret")) return Secret();
			if (text.Contains("/repository")) return Repository();

			return "Я тебя не понял";
		}

		private string Repository()
		{
			return "https://github.com/rufe69/Valera";
		}

		private string Secret()
		{
			return Environment.GetEnvironmentVariable("SECRET");
		}

		private string GetHelp()
		{
			return "/help -- помощь\r\n" +
				"/repository -- репозиторий проекта\r\n" +
				"Если хочешь узнать расписание, ты только напиши, на сегодня, на завтра, на понедельник.";
		}
	}
}
