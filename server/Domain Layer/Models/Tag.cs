namespace CodeCombat.Domain_Layer.Models;
public class Tag
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Content>? Contents { get; set; }
}