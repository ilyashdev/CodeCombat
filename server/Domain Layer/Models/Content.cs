using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CodeCombat.Domain_Layer.Models;

public class Content
{
    public Guid Id { get; set; }
    public User? Creator { get; set; }
    public string? ContentType { get; set; }
    public DateTime PublicTime { get; set; } = DateTime.UtcNow;
    public string? Description {get; set;}
    public ICollection<Tag>? Tags { get; set; }
    public string? Name { get; set; }
    public int InFavorite { get; set; }
    public ICollection<User>? Watched { get; set; }
    public ICollection<Comment>? Comments { get; set; }
    public ICollection<User>? UpUsers { get; set; }
    public ICollection<User>? DownUsers { get; set; }
    public ICollection<User>? InFavoriteUser { get; set; }
    public ICollection<Comment>? SubComments { get; set; }
}