using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bot.Schedule
{
    class Week
    {
        public Week()
        {
            Monday = new Day(DayOfWeek.Monday);
            Tuesday = new Day(DayOfWeek.Tuesday);
            Wednesday = new Day(DayOfWeek.Wednesday);
            Thursday = new Day(DayOfWeek.Thursday);
            Friday = new Day(DayOfWeek.Friday);
            Saturday = new Day(DayOfWeek.Saturday);
        }

        public string Parity { get; set; }
        public Day Monday { get; set; }
        public Day Tuesday { get; set; }
        public Day Wednesday { get; set; }
        public Day Thursday { get; set; }
        public Day Friday { get; set; }
        public Day Saturday { get; set; }
    }
}
