namespace CodeCombat.Domain_Layer.Models;

public class User
{
    public User(long telegramId, DateTime registerTime, DateTime subscriptionTime, ICollection<Content> myContent,
        ICollection<Content> favoriteContent, ICollection<Content> myUps, ICollection<Content> myDowns)
    {
        TelegramId = telegramId;
        RegisterTime = registerTime;
        SubscriptionTime = subscriptionTime;
        MyContent = myContent;
        FavoriteContent = favoriteContent;
        MyUps = myUps;
        MyDowns = myDowns;
    }

    public long TelegramId { get; set; }
    public DateTime RegisterTime { get; set; }
    public DateTime SubscriptionTime { get; set; }
    public ICollection<Content> MyContent { get; set; }
    public ICollection<Content> FavoriteContent { get; set; }
    public ICollection<Content> MyUps { get; set; }
    public ICollection<Content> MyDowns { get; set; }
}