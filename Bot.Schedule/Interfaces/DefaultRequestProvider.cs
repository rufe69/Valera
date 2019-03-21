using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Schedule
{
	class DefaultRequestProvider:IRequestProvider
    {
		public readonly string _group;

		public DefaultRequestProvider(string Group)
		{
			_group = Group;
		}

        public async Task<string> GetSchedule()
        {
            var request = WebRequest.Create("https://www.uni-dubna.ru/Schedule/LoadGroup");
            request.Method = "POST";

			var data = $"group={_group}";

            var byteArray = Encoding.UTF8.GetBytes(data);
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