using System;
using System.Globalization;
using System.Linq;

namespace Bot.Schedule
{
	class Schedule
	{
		private Week week;

		public Schedule(IRequestProvider requestProvider)
		{
			var parser = new ScheduleParser(requestProvider);
			week = parser.ParseSchedule();
		}

		public string All()
		{
			if (!WeekContainsLessons())
				return "Нет пар или группа указана не верно!";

			var message = "";
			message += $"{week.Parity}\r\n\r\n";
			message += $"{ByDayOfWeek(DayOfWeek.Monday, false)}\r\n";
			message += $"{ByDayOfWeek(DayOfWeek.Tuesday, false)}\r\n";
			message += $"{ByDayOfWeek(DayOfWeek.Wednesday, false)}\r\n";
			message += $"{ByDayOfWeek(DayOfWeek.Thursday, false)}\r\n";
			message += $"{ByDayOfWeek(DayOfWeek.Friday, false)}\r\n";
			message += $"{ByDayOfWeek(DayOfWeek.Saturday, false)}\r\n";

			return message;
		}

		public string ByDate(DateTime date)
		{
			return $"Расписание на {date.ToShortDateString()}\r\n" +
					$"{ByDayOfWeek(date.DayOfWeek, true)}";
		}

		public string ByDayOfWeek(DayOfWeek Day, bool Parity)
		{
			var dayObject = week.GetType()
								.GetProperties()
								.Where(x => x.PropertyType == typeof(Day))
								.ToDictionary(x => x.Name, x => (Day)x.GetValue(week))
								.First(x => x.Value.DayOfWeek == Day)
								.Value;

			

			var dayMessage = "";
			var RuDay = CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat.GetDayName(Day);

			if (Parity)
				dayMessage += $"{week.Parity}\r\n";
			dayMessage += $"{RuDay}:\r\n";
			if (!DayContainsLessons(dayObject))
				return $"{dayMessage} На этот день пар нет \r\n";

			dayMessage += $"1) {FormatLesson(dayObject.First)}\r\n";
			dayMessage += $"2) {FormatLesson(dayObject.Second)}\r\n";
			dayMessage += $"3) {FormatLesson(dayObject.Third)}\r\n";
			dayMessage += $"4) {FormatLesson(dayObject.Fourth)}\r\n";
			dayMessage += $"5) {FormatLesson(dayObject.Fifth)}\r\n";
			dayMessage += $"6) {FormatLesson(dayObject.Sixth)}\r\n";

			return dayMessage;
		}

		private string FormatLesson(string lesson)
		{
			if (lesson == "" || lesson == " ")
				return "-- -- -- -- --";

			if (lesson.Contains("/"))
			{
				var splited = lesson.Split("/");
				return $"Нечетная: {splited[1]}\r\n     Четная: {splited[0]}";
			}

			return lesson;
		}

		private bool WeekContainsLessons()
		{
			foreach (var prop in week.GetType().GetProperties().Where(x => x.PropertyType == typeof(Day)).ToDictionary(x => x.Name, x => (Day)x.GetValue(week)))
				if (DayContainsLessons(prop.Value))
					return true;
			return false;
		}

		private bool DayContainsLessons(Day day)
		{
			foreach (var dayProp in day.GetType().GetProperties().Where(x => x.PropertyType == typeof(string)))
			{
				var lesson = dayProp.GetValue(day).ToString();
				if (lesson != "" && lesson != " ")
					return true;
			}
			return false;
		}
	}
}
