namespace CodeCombat.Domain_Layer.Models;

public class User
{
    public Guid UserId {get;set;}
    public long TelegramId { get; set; }
    public string? Name { get; set; }
    public DateTime RegisterTime { get; set; }
    public DateTime SubscriptionTime { get; set; }
    public ICollection<Content> MyContent { get; set; }
    public ICollection<Content> FavoriteContent { get; set; }
    public ICollection<Content> MyUps { get; set; }
    public ICollection<Content> MyDowns { get; set; }
    public ICollection<Comment> MyComments { get; set; }
}