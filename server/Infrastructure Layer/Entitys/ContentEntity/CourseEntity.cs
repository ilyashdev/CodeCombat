namespace CodeCombat.DataAccess.Entity;
public class CourseEntity
{
    public Guid Id {get;set;}
    public long UserId { get; set; }
    public virtual UserEntity? User {get;set;}
    public string Title {get;set;} = string.Empty; 
    public string Desc {get;set;} = string.Empty;
    public int Like {get; set;} = 0;
    public int Dislike {get; set;} = 0;
    public DateTime PublicTime{ get; init; } = DateTime.UtcNow;
    public List<string> Tags {get;set;} = new();
    public virtual List<CommentEntity> Comments {get;set;}= new();
    public virtual List<ModuleEntity> Modules {get;set;} = new();
}