using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.DAI.DBModels
{
    class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronimyc { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string VKID { get; set; }

        public ICollection<Subscription> Subscriptions { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
