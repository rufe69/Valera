using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.DAI
{
    public interface IMessageConverter
    {
        IEnumerable<string> Convert(string message);
    }
}
