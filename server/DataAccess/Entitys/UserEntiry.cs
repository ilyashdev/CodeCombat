namespace CodeCombat.DataAccess.Entity;
public class UserEntity
{
        public long Id{ get; set; }
        public string Username{ get; set; } = string.Empty;
        public double CoinValue { get; set; } = 0;
        public DateTime RegisterTime{ get; init; } = DateTime.UtcNow;
}