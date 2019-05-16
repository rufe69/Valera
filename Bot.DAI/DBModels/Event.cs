using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.DAI.DBModels
{
    class Event
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string TableName { get; set; }
        public string FieldName { get; set; }
        public int NodeId { get; set; }
        public string OldData { get; set; }
        public string NewData { get; set; }

        public int EventTypeId { get; set; }
        public EventType EventType { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
