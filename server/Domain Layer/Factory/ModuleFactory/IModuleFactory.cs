using CodeCombat.Domain_Layer.Models.Course.Modules;
using CodeCombat.Presentation_Layer.Contract.Course;

namespace CodeCombat.Domain_Layer.Factory.ModuleFactory;

public interface IModuleFactory
{
    Module Create(ModuleRecord module);
}