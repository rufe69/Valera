using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Bot.Schedule
{
	class ScheduleParser
    {
        private readonly IRequestProvider _scheduleRequestProvider;

        public ScheduleParser(IRequestProvider scheduleRequestProvider)
        {
            _scheduleRequestProvider = scheduleRequestProvider;
        }

        public Week ParseSchedule()
        {
            var text = _scheduleRequestProvider.GetSchedule().Result;
            text = RemoveUnwanted(text);

            string pattern = string.Format(@"\<{0}.*?\>(?<Data>.+?)\<\/{0}\>", "td".Trim());
            // \<{0}.*?\> - открывающий тег
            // \<\/{0}\> - закрывающий тег
            // (?<tegData>.+?) - содержимое тега, записываем в группу tegData

            var regex = new Regex(pattern, RegexOptions.ExplicitCapture);
            var matches = regex.Matches(text);

            var res = "";
            var results = new List<string>();
            for (int i = 0; i < matches.Count; i++)
            {
                var buf = matches[i].ToString().Replace("<td>", string.Empty);
                buf = buf.Replace("</td>", string.Empty);
                res += " " + buf;
                if (i % 2 != 0)
                    res += "\r\n";
                results.Add(buf);
            }

            var week = AddSchedule(results);
            var reg = new Regex(@"Сейчас [А-Яа-я]+ неделя");
            week.Parity = reg.Match(text).Value;

            return week;
        }



        private string RemoveUnwanted(string text)
        {
            text = Regex.Replace(text, @"\s+", " ");
            //text = text.Replace("\r\n", string.Empty);
            text = text.Replace("\"", string.Empty);
            text = text.Replace(" class=position", string.Empty);
			text = text.Replace(" <span class=lecture>", "Лекция ");
			text = text.Replace(" <span>", string.Empty);
            text = text.Replace(" </span>", string.Empty);

            return text;
        }

        private Week AddSchedule(List<string> results)
        {
            var week = new Week();

            week.Monday.First = results[1];
            week.Monday.Second = results[3];
            week.Monday.Third = results[5];
            week.Monday.Fourth = results[7];
            week.Monday.Fifth = results[9];
            week.Monday.Sixth = results[11];

            week.Tuesday.First = results[13];
            week.Tuesday.Second = results[15];
            week.Tuesday.Third = results[17];
            week.Tuesday.Fourth = results[19];
            week.Tuesday.Fifth = results[21];
            week.Tuesday.Sixth = results[23];

            week.Wednesday.First = results[25];
            week.Wednesday.Second = results[27];
            week.Wednesday.Third = results[29];
            week.Wednesday.Fourth = results[31];
            week.Wednesday.Fifth = results[33];
            week.Wednesday.Sixth = results[35];

            week.Thursday.First = results[37];
            week.Thursday.Second = results[39];
            week.Thursday.Third = results[41];
            week.Thursday.Fourth = results[43];
            week.Thursday.Fifth = results[45];
            week.Thursday.Sixth = results[47];

            week.Friday.First = results[49];
            week.Friday.Second = results[51];
            week.Friday.Third = results[53];
            week.Friday.Fourth = results[55];
            week.Friday.Fifth = results[57];
            week.Friday.Sixth = results[59];

            week.Saturday.First = results[61];
            week.Saturday.Second = results[63];
            week.Saturday.Third = results[65];
            week.Saturday.Fourth = results[67];
            week.Saturday.Fifth = results[69];
            week.Saturday.Sixth = results[71];

            return week;
        }
    }
}