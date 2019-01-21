using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.DAI
{
    public interface IMessageSender
    {
        void Send(string recipient, string message);
    }
}
