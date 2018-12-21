using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Valera_bot
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
                "/repository -- репозиторий проекта";
        }
    }
}
