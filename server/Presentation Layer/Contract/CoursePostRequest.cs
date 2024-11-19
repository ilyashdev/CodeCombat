namespace CodeCombat.Contracts;
public record CoursePostRequest(string Title, string Description, List<Module>? Modules, List<string> Tags);