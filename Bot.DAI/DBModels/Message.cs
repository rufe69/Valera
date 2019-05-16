using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.DAI.DBModels
{
    class Message
    {
        public int Id { get; set; }
        public string Data { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
