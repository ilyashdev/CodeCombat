namespace CodeCombat.Presentation_Layer.Contract;

public record ContentDto(
    Guid Id,
    UserDto Creator,
    ICollection<string> Tags,
    string Type,
    DateTime PublicTime,
    long Up,
    long Down,
    ICollection<CommentDto> Comments);