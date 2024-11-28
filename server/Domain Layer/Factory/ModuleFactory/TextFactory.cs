using CodeCombat.Domain_Layer.Factory.Attribute;
using CodeCombat.Domain_Layer.Models.Course.Modules;
using CodeCombat.Presentation_Layer.Contract.Course;

namespace CodeCombat.Domain_Layer.Factory.ModuleFactory;

[ModuleFactory("Text")]
public class TextFactory : ModuleFactoryBase
{
    public override Module Create(ModuleRecord module)
    {
        return new TextModule(module.Name, module.Type, module.Data.Text);
    }
}