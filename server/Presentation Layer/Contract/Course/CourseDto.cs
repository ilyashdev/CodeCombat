namespace CodeCombat.Presentation_Layer.Contract.Course;

public record CourseDto(
    Guid Id,
    UserDto Creator,
    ICollection<string> Tags,
    string Type,
    DateTime PublicTime,
    long Up,
    long Down,
    ICollection<CommentDto> Comments) : ContentDto(Id, Creator, Tags, Type, PublicTime, Up, Down, Comments);