namespace CodeCombat.Contracts;
public record Comment(
    Guid Id,
    string  User,
    String Text,
    int Like,
    int Dislike,
    List<Comment> Subcomment
);