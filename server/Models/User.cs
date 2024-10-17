using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace CodeCombat.Models
{
    public class User
    {
        public User(string username, string email, string telegramToken)
        {
            Username = username;
            Email = email;
            CoinValue = 0;
            TelegramToken = telegramToken;
            RegisterTime = DateTime.UtcNow;
        }
        
        public Guid Id{ get; init; }
        public string Username{ get; set; }
        public string TelegramToken{ get; set; }
        public double CoinValue { get; set; }

        public string Email{ get; set; }

        public DateTime RegisterTime{ get; init; }

    }
}