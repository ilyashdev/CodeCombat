namespace CodeCombat.DataAccess;
public class CourseEntity : ContentEntity
{
    public ICollection<ModuleEntity>? Modules {get;set;}
}