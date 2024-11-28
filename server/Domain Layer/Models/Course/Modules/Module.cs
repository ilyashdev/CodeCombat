namespace CodeCombat.Model;

public class Module
{
    public Module(string name, string type)
    {
        Name = name;
        Type = type;
    }

    public string Name{get;set;}
    public string Type{get;set;}
}