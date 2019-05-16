using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.DAI.DBModels
{
    class EventType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
