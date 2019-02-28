using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.DAI.Defaults
{
    class MessageRequestBuilder 
    {
        private string _message;

        public MessageRequestBuilder()
        {
            _message = "";
        }

        public string Build()
        {
            return _message;
        }

        public void Add(string name, string value)
        {
            if (_message.Length != 0)
                _message += '&';
            _message += $"{name}={value}";
        }
    }
}
