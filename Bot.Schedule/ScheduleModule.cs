using System;
using System.Collections.Generic;
using System.Text;
using Bot.DAI;

namespace Bot.Schedule
{
    public class ScheduleModule : IModule
    {
        MessageConverter converter = new MessageConverter();
        //Dictionary<string, string> words;

        public string Convert(string message)
        {
            return converter.Convert(message);
        }

        public bool Contains(string message)
        {
			//TODO: realize it
			//return true;
			throw new NotImplementedException();
        }
    }
}
