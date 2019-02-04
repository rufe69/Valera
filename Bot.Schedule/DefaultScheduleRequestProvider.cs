using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Schedule
{
    class DefaultScheduleRequestProvider:IScheduleRequestProvider
    {
        public async Task<string> GetSchedule()
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

            var response = await request.GetResponseAsync();
            var ret = "";
            using (var stream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    ret = reader.ReadToEnd();
                }
            }

            response.Close();

            return ret;
        }
    }
}