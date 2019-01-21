using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bot.API
{
    public class Week
    {
        public Week()
        {
            Monday = new Day();
            Tuesday = new Day();
            Wednesday = new Day();
            Thursday = new Day();
            Friday = new Day();
            Saturday = new Day();
        }


        public string Parity { get; set; }
        public Day Monday { get; set; }
        public Day Tuesday { get; set; }
        public Day Wednesday { get; set; }
        public Day Thursday { get; set; }
        public Day Friday { get; set; }
        public Day Saturday { get; set; }

        public string GetSchedule()
        {
           return $"Понедельник:\r\n{Monday.GetSchedule()}\r\n\r\n" +
                $"Вторник:\r\n{Tuesday.GetSchedule()}\r\n\r\n" +
                $"Среда:\r\n{Wednesday.GetSchedule()}\r\n\r\n" +
                $"Четверг:\r\n{Thursday.GetSchedule()}\r\n\r\n" +
                $"Пятница:\r\n{Friday.GetSchedule()}\r\n\r\n" +
                $"Суббота:\r\n{Saturday.GetSchedule()}\r\n\r\n";
        }

        public string GetSchedule(DayOfWeek dayOfWeek)
        {
            switch(dayOfWeek)
            {
                case DayOfWeek.Monday: return $"Понедельник:\r\n{Monday.GetSchedule()}";
                case DayOfWeek.Tuesday: return $"Вторник:\r\n{Tuesday.GetSchedule()}";
                case DayOfWeek.Wednesday: return $"Среда:\r\n{Wednesday.GetSchedule()}";
                case DayOfWeek.Thursday: return $"Четверг:\r\n{Thursday.GetSchedule()}";
                case DayOfWeek.Friday: return $"Пятница:\r\n{Friday.GetSchedule()}";
                case DayOfWeek.Saturday: return $"Суббота:\r\n{Saturday.GetSchedule()}";
                default:return "На этот день нет расписания";
            }
        }
    }
}
