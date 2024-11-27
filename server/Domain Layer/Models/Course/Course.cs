namespace CodeCombat.Model;

public class Course : Content
{
    public ICollection<Module>Modules {get;set;}
}