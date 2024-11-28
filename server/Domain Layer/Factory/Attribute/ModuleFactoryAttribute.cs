namespace CodeCombat.Model;
[AttributeUsage(AttributeTargets.Class)]
public class ModuleFactoryAttribute : Attribute
{
public string Type { get; } 
public ModuleFactoryAttribute(string type)
{ 
    Type = type;
}
}