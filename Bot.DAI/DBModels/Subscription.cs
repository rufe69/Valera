using Bot.DAI.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.DAI.DBModels
{
    class Subscription
    {
        public int Id { get; set; }
        public Subscriptions Type { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
