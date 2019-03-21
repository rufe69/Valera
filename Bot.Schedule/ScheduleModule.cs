using System;
using System.Collections.Generic;
using Bot.DAI;

namespace Bot.Schedule
{
	public class ScheduleModule : IModule
    {
        public string Convert(string message)
        {
			return new MessageConverter().Convert(message);
        }

		public bool Contains(string message)
		{
			foreach (var val in GetSchedulesString())
				if (message.Contains(val))
					return true;
			return false;
		}

		private List<string> GetSchedulesString()
		{
			return new List<string>
			{
				"расписание",
				"рассписание",
				"росписание",
				"распесание",
				"роспесание",
				"росписание",
				"распесанее",
				"росписанее",
				"расписанее"
			};
		}
	}
}
