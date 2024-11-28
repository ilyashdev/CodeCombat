using CodeCombat.Infrastructure_Layer.Entity.Module;

namespace CodeCombat.Infrastructure_Layer.Entity.Content;

public class CourseEntity : ContentEntity
{
    public ICollection<ModuleEntity>? Modules { get; set; }
}