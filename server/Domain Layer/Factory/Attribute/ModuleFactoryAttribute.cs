namespace CodeCombat.Domain_Layer.Factory.Attribute;

[AttributeUsage(AttributeTargets.Class)]
public class ModuleFactoryAttribute : System.Attribute
{
    public ModuleFactoryAttribute(string type)
    {
        Type = type;
    }

    public string Type { get; }
}