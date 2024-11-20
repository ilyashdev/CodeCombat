using CodeCombat.DataAccess.Entity;

namespace CodeCombat.DataAccess.Factory;

public interface IModuleFactory
{
    public BaseModuleEntity CreateModule(dynamic data);
}