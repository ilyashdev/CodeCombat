namespace CodeCombat.Presentation_Layer.Contract.Course;

public record CourseDto(
    Guid Id,
    UserDto Creator,
    string Description,
    ICollection<string>? Tags,
    string Type,
    DateTime PublicTime,
    long Up,
    long Down,
    ICollection<ModuleDto>? Modules
    );