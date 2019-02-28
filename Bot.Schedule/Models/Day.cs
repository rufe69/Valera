using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bot.Schedule
{
    class Day
    {
        public DayOfWeek DayOfWeek { get; }

        public string First { get; set; }
        public string Second { get; set; }
        public string Third { get; set; }
        public string Fourth { get; set; }
        public string Fifth { get; set; }
        public string Sixth { get; set; }

        public Day(DayOfWeek day)
        {
            DayOfWeek = day;
        }
    }
}
