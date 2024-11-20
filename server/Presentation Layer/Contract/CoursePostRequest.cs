namespace CodeCombat.Contracts;
public record CoursePostRequest(string Title, string Description, List<dynamic>? Modules, List<string> Tags);