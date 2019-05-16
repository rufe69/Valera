using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.DAI.DBModels
{
    class Key
    {
        public int Id { get; set; }
        public string Word { get; set; }

        public int InformationId { get; set; }
        public Information Information { get; set; }
    }
}
