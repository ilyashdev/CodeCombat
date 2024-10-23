namespace CodeCombat.DataAccess.Entity;

public class BaseEntity
{
    public UserEntity? User {get;set;}
    public string Title {get;set;} = string.Empty; 
    public string Desc {get;set;} = string.Empty;
    public DateTime PublicTime{ get; init; } = DateTime.UtcNow;
    public List<string> Tags {get;set;} = new List<string>();
    public List<CommentEntity> comments = new List<CommentEntity>();
}