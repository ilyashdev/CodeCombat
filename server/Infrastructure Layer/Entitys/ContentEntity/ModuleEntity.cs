namespace CodeCombat.DataAccess.Entity;

public class ModuleEntity
{
    public Guid Id {get; set;}
    public string Name {set; get;} = string.Empty;
    public string Type {set;get;} = string.Empty;
    public string Data {set; get;} = string.Empty;
    public virtual CourseEntity? Course {set; get;} 
}