using CodeCombat.Infrastructure_Layer.Entity.Data;

namespace CodeCombat.Infrastructure_Layer.Entity.Content;

public class ContentEntity
{
    public Guid Id { get; set; }
    public UserEntity? Creator { get; set; }
    public string? ContentType { get; set; }
    public DateTime PublicTime { get; set; }
    public string? Name { get; set; }
    public ICollection<string>? Tags { get; set; }
    public ICollection<UserEntity>? UpUsers { get; set; }
    public ICollection<UserEntity>? DownUsers { get; set; }
    public ICollection<UserEntity>? InFavoriteUser { get; set; }
    public ICollection<CommentEntity>? Comments { get; set; }
}