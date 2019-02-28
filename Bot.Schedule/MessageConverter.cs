using System;
using System.Collections.Generic;
using System.Text;
using Bot.DAI;

namespace Bot.Schedule
{
    class MessageConverter
    {
        public string Convert(string Message)
        {
            var requestProvider = new DefaultScheduleRequestProvider();
            var scheduler = new Schedule(requestProvider);

            if (Message.ToLower().Contains("понедельник"))
                return scheduler.ByDayOfWeek(DayOfWeek.Monday);
            if (Message.ToLower().Contains("вторник"))
                return scheduler.ByDayOfWeek(DayOfWeek.Tuesday);
            if (Message.ToLower().Contains("сред"))
                return scheduler.ByDayOfWeek(DayOfWeek.Wednesday);
            if (Message.ToLower().Contains("четверг"))
                return scheduler.ByDayOfWeek(DayOfWeek.Thursday);
            if (Message.ToLower().Contains("пятниц"))
                return scheduler.ByDayOfWeek(DayOfWeek.Friday);
            if (Message.ToLower().Contains("суббот"))
                return scheduler.ByDayOfWeek(DayOfWeek.Saturday);

            if (Message.ToLower().Contains("послезавтра"))
            {
                var now = DateTime.Now;
                return scheduler.ByDayOfWeek(now.AddDays(2).DayOfWeek);
            }
            if (Message.ToLower().Contains("завтра"))
            {
                var now = DateTime.Now;
                return scheduler.ByDayOfWeek(now.AddDays(1).DayOfWeek);
            }

            if (Message.ToLower().Contains("позавчера"))
            {
                var now = DateTime.Now;
                // TODO: Исправить баг, который будет возникать, если это будет первый или второй день месяца
                var yesterday = new DateTime(now.Year, now.Month, now.Day - 2).DayOfWeek;
                return scheduler.ByDayOfWeek(yesterday);
            }
            if (Message.ToLower().Contains("вчера"))
            {
                var now = DateTime.Now;
                // TODO: Исправить баг, который будет возникать, если это будет первый день месяца
                var yesterday = new DateTime(now.Year, now.Month, now.Day - 1).DayOfWeek;
                return scheduler.ByDayOfWeek(yesterday);
            }
            if (Message.ToLower().Contains("сегодня"))
            {
                return scheduler.ByDayOfWeek(DateTime.Now.DayOfWeek);
            }


            if (Message.ToLower().Contains("расписание"))
            {
                return scheduler.All();
            }

            return "Я тебя не понял";
        }
    }
}
