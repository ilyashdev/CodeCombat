namespace CodeCombat.Model;
public class Comment
{
public Guid Id {get;set;}
public string? Text {get;set;}
public int UpUsers{get;set;}
public int DownUsers{get;set;}
public ICollection<Comment>? Subcomments {get;set;}
}