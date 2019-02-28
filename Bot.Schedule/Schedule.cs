﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bot.Schedule
{
    class Schedule
    {
        private Week week;

        public Schedule(IScheduleRequestProvider requestProvider)
        {
            var parser = new ScheduleParser(requestProvider);
            week = parser.ParseSchedule();
        }

        public string All()
        {
            var message = "";
            message += $"{week.Parity}\r\n\r\n";
            message += $"{ByDayOfWeek(DayOfWeek.Monday)}\r\n";
            message += $"{ByDayOfWeek(DayOfWeek.Tuesday)}\r\n";
            message += $"{ByDayOfWeek(DayOfWeek.Wednesday)}\r\n";
            message += $"{ByDayOfWeek(DayOfWeek.Thursday)}\r\n";
            message += $"{ByDayOfWeek(DayOfWeek.Friday)}\r\n";
            message += $"{ByDayOfWeek(DayOfWeek.Saturday)}\r\n";
            
            return message;
        }

        public string ByDate(DateTime date)
        {
            return $"Расписание на {date.ToShortDateString()}\r\n" +
                    $"{ByDayOfWeek(date.DayOfWeek)}";
        }

        public string ByDayOfWeek(DayOfWeek day)
        {
            if (day == DayOfWeek.Sunday)
                return "В воскресенье нет пар.";

            var daySchedule = "";
            var dayOfWeek = week.GetType()
                                .GetProperties()
                                .Where(x => x.PropertyType == typeof(Day))
                                .ToDictionary(x => x.Name, x => (Day)x.GetValue(week))
                                .First(x => x.Value.DayOfWeek == day)
                                .Value;

            daySchedule += $"{day}:\r\n";
            daySchedule += $"1) {GetLesson(dayOfWeek.First)}\r\n";
            daySchedule += $"2) {GetLesson(dayOfWeek.Second)}\r\n";
            daySchedule += $"3) {GetLesson(dayOfWeek.Third)}\r\n";
            daySchedule += $"4) {GetLesson(dayOfWeek.Fourth)}\r\n";
            daySchedule += $"5) {GetLesson(dayOfWeek.Fifth)}\r\n";
            daySchedule += $"6) {GetLesson(dayOfWeek.Sixth)}\r\n";

            return daySchedule;
        }

        private string GetLesson(string lesson)
        {
            if (lesson == "" || lesson == " ")
                return "----------";

            if(lesson.Contains("/"))
            {
                var splited = lesson.Split("/");
                return week.Parity == "Сейчас четная неделя" ? splited[1] : splited[0];
            }

            return lesson;
        }
    }
}
