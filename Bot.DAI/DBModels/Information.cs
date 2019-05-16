using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.DAI.DBModels
{
    class Information
    {
        public int Id { get; set; }
        public string Data { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Key> Keys { get; set; }
    }
}
