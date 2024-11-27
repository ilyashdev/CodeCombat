namespace CodeCombat.Model;
public class Content
{
    public Guid Id {get;set;}
    public User? Creator {get; set;}
    public string? ContentType {get;set;}
    public DateTime PublicTime {get;set;}
    public ICollection<string>? Tags {get;set;}
    public string? Name {get;set;}
    public int Up{get;set;}
    public int Down{get;set;}
    public int InFavoriteUser{get;set;}
    public ICollection<Comment>? Comments {get;set;}
}