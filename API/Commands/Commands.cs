using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Bot.API
{
    public class Commands
    {
        internal string ConvertMessage(string text)
        {
            if(text.Contains("/help")) return GetHelp();
            if(text.Contains("/secret")) return Secret();
            if(text.Contains("/repository")) return Repository();

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
                "Если хочешь узнать расписание, отправь смс на короткий номер 8-800-555-35-35 со словом \"Расписание\" и я тебе обязательно напишу, малыш.\r\n" +
                "Че, повелся? Да гоню я, чё ты.\r\n" +
                "Короче, если нужно расписание ты только напиши, на сегодня, на завтра, на понедельник, ты только напиши.";
        }
    }
}
