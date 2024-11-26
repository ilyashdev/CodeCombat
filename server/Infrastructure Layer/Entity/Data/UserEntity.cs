namespace CodeCombat.DataAccess;
public class UserEntity
{
    public long TelegramId {get;set;}
    public DateTime RegisterTime {get;set;}
    public DateTime? SubscriptionTime {get;set;}
    public ICollection<ContentEntity>? MyContent {get;set;} 
    public ICollection<ContentEntity>? FavoriteContent {get;set;}

}