using CodeCombat.Infrastructure_Layer.Entity.Content;

namespace CodeCombat.Infrastructure_Layer.Entity.Module;

public class ModuleEntity
{
    public int Id { get; set; }
    public string? Type { get; set; }
    public string? Name { get; set; }
    public CourseEntity? Course { get; set; }
}