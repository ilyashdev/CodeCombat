using CodeCombat.Contract;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CodeCombat.Model;
[ModuleFactory("Text")]
public class TextFactory : ModuleFactoryBase
{
    override public Module Create(ModuleRecord module)
    {
        return new TextModule(module.Name,module.Type,module.Data.Text);
    }
}