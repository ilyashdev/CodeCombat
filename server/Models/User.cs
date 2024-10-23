using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;
using CodeCombat.DataAccess.Entity;

namespace CodeCombat.Models
{
    public class User
    {
        public User(long id,string username, string telegramToken)
        {
            Id=id;
            Username = username;
            CoinValue = 0;
            RegisterTime = DateTime.UtcNow;
        }
        
        public long Id{ get; set; }
        public string Username{ get; set; }
        public string TelegramToken{ get; set; } = "1";
        public double CoinValue { get; set; }
        public DateTime RegisterTime{ get; init; }
    }
}