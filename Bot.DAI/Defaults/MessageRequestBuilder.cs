using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.DAI.Defaults
{
    class MessageRequestBuilder 
    {
        private string _message;

        public MessageRequestBuilder(string system)
        {
            _message = system;
        }

        public string Build()
        {
            return _message;
        }

        public void Add(string name, string value)
        {
            if (_message[_message.Length-1] != '?')
                _message += '&';
            _message += $"{name}={value}";
        }
    }
}
