using Bot.DAI.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.DAI.DBModels
{
    class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronimyc { get; set; }
        public string TableNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Roles Role { get; set; }
        public string SaltedPasswordHash { get; set; }
        public string Salt { get; set; }

        public ICollection<Token> Tokens { get; set; }
        public ICollection<Information> Informations { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
