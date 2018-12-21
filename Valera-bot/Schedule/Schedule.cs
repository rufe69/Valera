using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Valera_bot
{
    public class Schedule
    {
        public string ConvertMessage(string Message)
        {
                var week = ParseSchedule();

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

        public Week ParseSchedule()
        {
            Week week = new Week();
            var text = GetScheduleFromUniDubnaRu();
            text = Regex.Replace(text, @"\s+", " ");
            text = text.Replace("\r\n", string.Empty);
            text = text.Replace("\"", string.Empty);
            text = text.Replace(" class=position", string.Empty);
            text = text.Replace(" class=lecture", string.Empty);
            text = text.Replace(" <span>", string.Empty);
            text = text.Replace(" </span>", string.Empty);

            Regex reg = new Regex(@"Сейчас [А-Яа-я]+ неделя");
            week.Parity = reg.Match(text).Value;

            string pattern = string.Format(@"\<{0}.*?\>(?<Data>.+?)\<\/{0}\>", "td".Trim());
            // \<{0}.*?\> - открывающий тег
            // \<\/{0}\> - закрывающий тег
            // (?<tegData>.+?) - содержимое тега, записываем в группу tegData

            Regex regex = new Regex(pattern, RegexOptions.ExplicitCapture);
            MatchCollection matches = regex.Matches(text);

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

        private string GetScheduleFromUniDubnaRu()
        {
            WebRequest request = WebRequest.Create("https://www.uni-dubna.ru/Schedule/LoadGroup");
            request.Method = "POST";

            var data = "limit=25" +
                "&faculty=%D0%98%D0%BD%D1%81%D1%82%D0%B8%D1%82%D1%83%D1%82+%D1%81%D0%B8%D1%81%D1%82%D0%B5%D0%BC%D0%BD%D0%BE%D0%B3%D0%BE+%D0%B0%D0%BD%D0%B0%D0%BB%D0%B8%D0%B7%D0%B0+%D0%B8+%D1%83%D0%BF%D1%80%D0%B0%D0%B2%D0%BB%D0%B5%D0%BD%D0%B8%D1%8F" +
                "&course=4+%D0%BA%D1%83%D1%80%D1%81" +
                "&group=4281";

            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            using (var dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            var response = request.GetResponse();
            var ret = "";
            using (var stream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    ret = reader.ReadToEnd();
                }
            }

            return ret;
        }
    }
}
