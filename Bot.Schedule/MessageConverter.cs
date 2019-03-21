using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Bot.Schedule
{
	class MessageConverter
    {
		private Dictionary<string, string> words;

		private string _groupMissMessage;
		private string _infoMessage;
		private string _saturdayMessage;

		public MessageConverter()
		{
			SetDictionary();
			SetDefaultMessages();
		}



		public string Convert(string Message)
		{
			var param = words.FirstOrDefault(x => Message.Contains($" {x.Key} ")).Value;
			if(param == "help")
				return _infoMessage;

			var group = new Regex(@" \d\d\d\d ").Match(Message).Value;
			if (group == "")
				return $"{_groupMissMessage} \r\n\r\n{_infoMessage}";

			var requestProvider = new DefaultRequestProvider(group);
			var scheduler = new Schedule(requestProvider);
			
			switch (param)
			{
				case "пн": return scheduler.ByDayOfWeek(DayOfWeek.Monday, true);
				case "вт": return scheduler.ByDayOfWeek(DayOfWeek.Tuesday, true);
				case "ср": return scheduler.ByDayOfWeek(DayOfWeek.Wednesday, true);
				case "чт": return scheduler.ByDayOfWeek(DayOfWeek.Thursday, true);
				case "пт": return scheduler.ByDayOfWeek(DayOfWeek.Friday, true);
				case "сб": return scheduler.ByDayOfWeek(DayOfWeek.Saturday, true);
				case "вс": return _saturdayMessage;
				case "послезавтра": return scheduler.ByDayOfWeek(DateTime.Now.AddDays(2).DayOfWeek, true);
				case "завтра": return scheduler.ByDayOfWeek(DateTime.Now.AddDays(1).DayOfWeek, true);
				case "сегодня": return scheduler.ByDayOfWeek(DateTime.Now.DayOfWeek, true);
				default: return scheduler.All();
			}

        }



		private void SetDefaultMessages()
		{
			_groupMissMessage = "Номер группы не указан!";
			_infoMessage = "Чтобы узнать расписание напиши слово \"Расписание\"(регистр не важен) и номер группы.\r\n" +
									"Если необходимо узнать расписание на конкретный день можно написать название дня полностью или сокращенно.\r\n" +
									"Примеры:\r\n		Расписание 4281 пн \r\n		Расписание 4281 завтра";
			_saturdayMessage = "В воскресенье пар нет";
		}

		private void SetDictionary()
		{
			words = new Dictionary<string, string>();

			#region Помощь
			words.Add("помощь", "help");
			words.Add("help", "help");
			words.Add("h", "help");
			words.Add("-h", "help");
			words.Add("--help", "help");
			words.Add("помощ", "help");
			words.Add("помоги", "help");
			words.Add("как делать", "help");
			words.Add("инфо", "help");
			words.Add("информация", "help");
			words.Add("как работать", "help");
			words.Add("что делать", "help");

			#endregion

			#region Понедельник
			words.Add("понедельник", "пн");
			words.Add("пон", "пн");
			words.Add("пн", "пн");

			words.Add("панидельник", "пн");
			words.Add("панедельник", "пн");
			words.Add("понидельник", "пн");
			words.Add("пониделник", "пн");
			words.Add("паниделник", "пн");
			#endregion

			#region Вторник
			words.Add("вторник", "вт");
			words.Add("вт", "вт");

			words.Add("вторнек", "вт");
			words.Add("вторнег", "вт");
			words.Add("вторниг", "вт");
			words.Add("фторник", "вт");
			words.Add("фторниг", "вт");
			words.Add("фторнег", "вт");
			words.Add("фторнек", "вт");
			#endregion

			#region Среда
			words.Add("среда", "ср");
			words.Add("ср", "ср");

			words.Add("срида", "ср");
			words.Add("сред", "ср");
			#endregion

			#region Четверг
			words.Add("четверг", "чт");
			words.Add("чт", "чт");

			words.Add("читверг", "чт");
			words.Add("читверк", "чт");
			words.Add("четверк", "чт");
			#endregion

			#region Пятница
			words.Add("пятница", "пт");
			words.Add("пт", "пт");

			words.Add("пятнеца", "пт");
			#endregion

			#region Суббота
			words.Add("суббота", "сб");
			words.Add("сб", "сб");

			words.Add("субота", "сб");
			#endregion

			#region Воскресенье
			words.Add("воскресенье", "вс");
			words.Add("вс", "вс");

			words.Add("васкресенье", "вс");
			words.Add("васкрисенье", "вс");
			words.Add("воскрисенье", "вс");
			words.Add("васкрисение", "вс");
			words.Add("васкресение", "вс");
			words.Add("воскрисение", "вс");
			words.Add("воскр", "вс");
			words.Add("васкр", "вс");
			words.Add("воскрес", "вс");
			words.Add("васкрес", "вс");
			words.Add("воскрис", "вс");
			words.Add("васкрис", "вс");
			#endregion

			#region Позавчера
			words.Add("позавчера", "позавчера");

			words.Add("пзвчр", "позавчера");
			words.Add("пз", "позавчера");
			words.Add("пазавчера", "позавчера");
			words.Add("пазавчира", "позавчера");
			words.Add("позовчера", "позавчера");
			words.Add("пазовчера", "позавчера");
			words.Add("пазовчира", "позавчера");
			#endregion

			#region Вчера
			words.Add("вчера", "вчера");

			words.Add("вчира", "вчера");
			words.Add("вчр", "вчера");
			words.Add("вч", "вчера");
			#endregion

			#region Сегодня
			words.Add("сегодня", "сегодня");

			words.Add("седня", "сегодня");
			words.Add("сег", "сегодня");
			words.Add("сигодня", "сегодня");
			words.Add("севодня", "сегодня");
			words.Add("сиводня", "сегодня");
			words.Add("сегодне", "сегодня");
			words.Add("сигодне", "сегодня");
			words.Add("седне", "сегодня");
			words.Add("сгдн", "сегодня");
			#endregion

			#region Завтра
			words.Add("завтра", "завтра");

			words.Add("завтро", "завтра");
			words.Add("зв", "завтра");
			words.Add("зав", "завтра");
			#endregion

			#region Послезавтра
			words.Add("послезавтра", "послезавтра");

			words.Add("послизавтра", "послезавтра");
			words.Add("послизавтро", "послезавтра");
			words.Add("пслзв", "послезавтра");
			words.Add("послезавтро", "послезавтра");
			#endregion
		}
	}
}
