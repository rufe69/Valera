using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.DAI.DBModels
{
    class Token
    {
        public int Id { get; set; }
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public DateTime Issued { get; set; }
        public string RefreshToken { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
