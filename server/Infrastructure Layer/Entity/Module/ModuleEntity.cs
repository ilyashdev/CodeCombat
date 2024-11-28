namespace CodeCombat.DataAccess;
public class ModuleEntity
{
    public int Id {get;set;}
    public string? Type {get;set;}
    public string? Name {get;set;}
    public CourseEntity? Course {get;set;}
}