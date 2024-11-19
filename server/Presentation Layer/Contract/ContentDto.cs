namespace CodeCombat.Contracts;

public record ContentDto(Guid Id,string Author,string Title,string Description, List<string> Tags, int Like, int Dislike);