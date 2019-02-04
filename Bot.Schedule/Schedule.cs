using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bot.Schedule
{
    public class Schedule
    {
        private ScheduleParser parser;

        public Schedule()
        {
            DefaultScheduleRequestProvider scheduleRequestProvider = new DefaultScheduleRequestProvider();
            parser = new ScheduleParser(scheduleRequestProvider);
        }

        public string ConvertMessage(string Message)
        {
            var week = parser.ParseSchedule();

            if (Message.ToLower().Contains("понедельник"))
                return week.GetSchedule(DayOfWeek.Monday);
            if (Message.ToLower().Contains("вторник"))
                return week.GetSchedule(DayOfWeek.Tuesday);
            if (Message.ToLower().Contains("сред"))
                return week.GetSchedule(DayOfWeek.Wednesday);
            if (Message.ToLower().Contains("четверг"))
                return week.GetSchedule(DayOfWeek.Thursday);
            if (Message.ToLower().Contains("пятниц"))
                return week.GetSchedule(DayOfWeek.Friday);
            if (Message.ToLower().Contains("суббот"))
                return week.GetSchedule(DayOfWeek.Saturday);

            if (Message.ToLower().Contains("послезавтра"))
            {
                var now = DateTime.Now;
                return week.GetSchedule(now.AddDays(2).DayOfWeek);
            }
            if (Message.ToLower().Contains("завтра"))
            {
                var now = DateTime.Now;
                return week.GetSchedule(now.AddDays(1).DayOfWeek);
            }
            
            if (Message.ToLower().Contains("позавчера"))
            {
                var now = DateTime.Now;
                // TODO: Исправить баг, который будет возникать, если это будет первый или второй день месяца
                var yesterday = new DateTime(now.Year, now.Month, now.Day - 2).DayOfWeek;
                return week.GetSchedule(yesterday);
            }
            if (Message.ToLower().Contains("вчера"))
            {
                var now = DateTime.Now;
                // TODO: Исправить баг, который будет возникать, если это будет первый день месяца
                var yesterday = new DateTime(now.Year, now.Month, now.Day - 1).DayOfWeek;
                return week.GetSchedule(yesterday);
            }
            if (Message.ToLower().Contains("сегодня"))
            {
                return week.GetSchedule(DateTime.Now.DayOfWeek);
            }


            if (Message.ToLower().Contains("расписание"))
            {
                return week.GetSchedule();
            }

            return "Я тебя не понял";
        }

        public string ScheduleByDate(DateTime date)
        {
            var week = ParseSchedule();
            return week.GetSchedule(date.DayOfWeek);
        }

        public string AllSchedule()
        {
            var week = ParseSchedule();
            return week.GetSchedule(); 
        }

        public string ScheduleByDayOfWeek(DayOfWeek dayOfWeek)
        {
            var week = ParseSchedule();
            return week.GetSchedule(dayOfWeek);
        }
    }
}
