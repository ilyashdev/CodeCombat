namespace CodeCombat.Domain_Layer.Models.Course.Modules;

public abstract class Module
{
    public Guid ModuleId { get; set; }
    public Course? InCourse { get; set; }
    public string? ModuleType { get; set; }
    public string Name { get; set; }
    public abstract Result GetResult();
}