using CodeCombat.Contracts;

namespace CodeCombat.Models
{
    public class User
    {
        public User(long id,string username)
        {
            Id=id;
            Username = username;
            CoinValue = 0;
            RegisterTime = DateTime.UtcNow;
        }

        public User(TInitRequest request)
        {
            Id=request.id;
            Username = request.username;
        }
        
        public long Id{ get; set; }
        public string Username{ get; set; }
        public double CoinValue { get; set; }
        public DateTime RegisterTime{ get; init; }
    }
}