using CodeCombat.Domain_Layer.Factory.Attribute;
using CodeCombat.Domain_Layer.Models.Course.Modules;
using CodeCombat.Presentation_Layer.Contract.Course;

namespace CodeCombat.Domain_Layer.Factory.ModuleFactory;

[ModuleFactory("Text")]
public class TextFactory : IModuleFactory
{
    public Module Create(ModuleRecord module)
    {
        var textModule = new TextModule
        {
            Name = module.Name,
            ModuleType = module.Type
        };
        textModule.Text = (string)module.Data["Text"] 
        ?? 
        throw new InvalidOperationException("No text field");
        return textModule;
    }
}