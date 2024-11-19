namespace CodeCombat.DataAccess.Entity;

public class BaseContentEntity
{
    public Guid Id {get;set;}
    public UserEntity User {get;set;}
    public string Title {get;set;} = string.Empty; 
    public string Desc {get;set;} = string.Empty;
    public int Like {get; set;} = 0;
    public int Dislike {get; set;} = 0;
    public DateTime PublicTime{ get; init; } = DateTime.UtcNow;
    public List<string> Tags {get;set;} = new List<string>();
    public List<CommentEntity> comments = new List<CommentEntity>();
}