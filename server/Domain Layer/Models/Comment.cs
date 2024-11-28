namespace CodeCombat.Model;
public class Comment
{
    public Comment(Guid id, string text, int upUsers, int downUsers, ICollection<Comment>? subcomments)
    {
        Id = id;
        Text = text;
        UpUsers = upUsers;
        DownUsers = downUsers;
        Subcomments = subcomments;
    }

public Guid Id {get;set;}
public string Text {get;set;}
public int UpUsers{get;set;}
public int DownUsers{get;set;}
public ICollection<Comment>? Subcomments {get;set;}
}