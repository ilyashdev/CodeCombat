namespace CodeCombat.DataAccess.Entity;
public class PostEntity
{
    public string Author {get;set;} = string.Empty;
    public string Title {get;set;} = string.Empty; 
    public string Desc {get;set;} = string.Empty;
    public List<string> Tags {get;set;} = new List<string>();
    public string Post = string.Empty;
    public List<CommentEntity> comments = new List<CommentEntity>();
}