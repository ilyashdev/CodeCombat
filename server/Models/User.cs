using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace CodeCombat.Models
{
    public class User
    {
        public User(long id,string username, string telegramToken)
        {
            Id=id;
            Username = username;
            CoinValue = 0;
            TelegramToken = telegramToken;
            RegisterTime = DateTime.UtcNow;
            solutions = new List<SolutionBlock>();
        }
        
        public long Id{ get; set; }
        public string Username{ get; set; }
        public string TelegramToken{ get; set; }
        public double CoinValue { get; set; }
        public DateTime RegisterTime{ get; init; }
        public List<SolutionBlock> solutions{ get; init; }
    }
}