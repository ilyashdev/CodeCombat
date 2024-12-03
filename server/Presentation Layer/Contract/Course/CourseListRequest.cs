namespace CodeCombat.Presentation_Layer.Contract;
public record CourseListRequest(string filter, ICollection<string> tags);