using CodeCombat.Infrastructure_Layer.Entity.Data;

namespace CodeCombat.Infrastructure_Layer.Entity.Content;

public class CommentEntity
{
    public Guid Id { get; set; }
    public UserEntity? Creator { get; set; }
    public string? Text { get; set; }
    public ContentEntity? Content { get; set; }
    public ICollection<UserEntity>? UpUsers { get; set; }
    public ICollection<UserEntity>? DownUsers { get; set; }
    public ICollection<CommentEntity>? Subcomments { get; set; }
}