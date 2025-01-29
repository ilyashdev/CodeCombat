namespace CodeCombat.Presentation_Layer.Contract;
public record ContentListRequest(string filter, ICollection<string> tags);