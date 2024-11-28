using CodeCombat.Infrastructure_Layer.Entity.Content;

namespace CodeCombat.Infrastructure_Layer.Entity.Data;

public class UserEntity
{
    public long TelegramId { get; set; }
    public DateTime RegisterTime { get; set; }
    public DateTime? SubscriptionTime { get; set; }
    public ICollection<ContentEntity>? MyContent { get; set; }
    public ICollection<ContentEntity>? FavoriteContent { get; set; }
    public ICollection<ContentEntity>? MyUps { get; set; }
    public ICollection<ContentEntity>? MyDowns { get; set; }
    public ICollection<CommentEntity>? MyComments { get; set; }
}