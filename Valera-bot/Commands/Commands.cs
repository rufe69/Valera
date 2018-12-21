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
            switch(text)
            {
                case "/help": return GetHelp();
                case "/secret":return Secret();
                case "/repository": return Repository();
                default: return "Я тебя не понял";
            }
        }

        private string Repository()
        {
            return "https://github.com/rufe69/Valera";
        }

        private string Secret()
        {
            return MD5.Create(Environment.GetEnvironmentVariable("SECRET")).ToString();
        }

        private string GetHelp()
        {
            return "/help -- помощь\r\n" +
                "/repository -- репозиторий проекта";
        }
    }
}
