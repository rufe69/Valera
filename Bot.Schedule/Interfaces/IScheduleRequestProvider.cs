using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Schedule
{
    interface IScheduleRequestProvider
    {
        Task<string> GetSchedule();
    }
}
