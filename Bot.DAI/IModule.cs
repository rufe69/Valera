using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.DAI
{
    public interface IModule
    {
        string Convert(string message);
        bool Contains(string message);
    }
}
