using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Valera_bot
{
    public class Day
    {
        public string First { get; set; }
        public string Second { get; set; }
        public string Third { get; set; }
        public string Fourth { get; set; }
        public string Fifth { get; set; }
        public string Sixth { get; set; }

        public string GetSchedule()
        {
            return $"1) {First}\r\n" +
                  $"2) {Second}\r\n" +
                  $"3) {Third}\r\n" +
                  $"4) {Fourth}\r\n" +
                  $"5) {Fifth}\r\n" +
                  $"6) {Sixth}\r\n";
        }
    }
}
