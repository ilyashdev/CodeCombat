namespace CodeCombat.Domain_Layer.Models;

public class Content
{
    public Content(Guid id, User? creator, string? contentType, DateTime publicTime, ICollection<string>? tags,
        string? name, int up, int down, int inFavoriteUser, ICollection<Comment>? comments)
    {
        Id = id;
        Creator = creator;
        ContentType = contentType;
        PublicTime = publicTime;
        Tags = tags;
        Name = name;
        Up = up;
        Down = down;
        InFavoriteUser = inFavoriteUser;
        Comments = comments;
    }

    public Guid Id { get; set; }
    public User? Creator { get; set; }
    public string? ContentType { get; set; }
    public DateTime PublicTime { get; set; }
    public ICollection<string>? Tags { get; set; }
    public string? Name { get; set; }
    public int Up { get; set; }
    public int Down { get; set; }
    public int InFavoriteUser { get; set; }
    public ICollection<Comment>? Comments { get; set; }
}