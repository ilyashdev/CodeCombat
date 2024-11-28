using CodeCombat.Contract;

namespace CodeCombat.Model;
public interface IModuleFactory
{
    Module Create(ModuleRecord module);
}