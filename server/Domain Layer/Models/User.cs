namespace CodeCombat.Model;
public class User
{
    public long TelegramId {get;set;}
    public DateTime RegisterTime {get;set;}
    public DateTime? SubscriptionTime {get;set;}
    public ICollection<Content>? MyContent {get;set;} 
    public ICollection<Content>? FavoriteContent {get;set;}
    public ICollection<Content>? MyUps {get;set;}
    public ICollection<Content>? MyDowns {get;set;}
}