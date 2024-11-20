using CodeCombat.DataAccess.Entity;

namespace CodeCombat.DataAccess.Fabric;

public interface IModuleFabric
{
    BaseModuleEntity CreateModule(dynamic data);
}