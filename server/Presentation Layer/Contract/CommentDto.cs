namespace CodeCombat.Presentation_Layer.Contract;

public record CommentDto(
    Guid Id,
    UserDto Creator,
    string Text,
    DateTime PublicTime,
    ICollection<CommentDto>? Subcomment);