namespace CodeCombat.Presentation_Layer.Contract;

public record ContentDto(
    Guid Id,
    string Name,
    string ContentType,
    UserDto Creator,
    ICollection<string> Tags,
    DateTime PublicTime,
    int Watched,
    long Up,
    long Down
);
