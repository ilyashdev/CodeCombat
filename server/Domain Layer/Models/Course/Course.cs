using CodeCombat.Domain_Layer.Models.Course.Modules;

namespace CodeCombat.Domain_Layer.Models.Course;

public class Course : Content
{
    public ICollection<Module>? Modules { get; set; }
}