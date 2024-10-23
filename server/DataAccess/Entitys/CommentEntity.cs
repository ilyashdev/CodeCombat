namespace CodeCombat.DataAccess.Entity;
public class CommentEntity
{
    public UserEntity? User{get;set;}
    public string Comment{get;set;} = string.Empty;
    public int Like = 0;
    public int Dislike = 0;
    public List<CommentEntity> Subcomment {get;set;} = new List<CommentEntity>();
}