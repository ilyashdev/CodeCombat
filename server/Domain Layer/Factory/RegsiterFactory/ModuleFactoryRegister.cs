using System.Reflection;
using CodeCombat.Domain_Layer.Factory.Attribute;

namespace CodeCombat.Domain_Layer.Factory.ModuleFactory;

public class ModuleFactoryRegister
{
    private readonly Dictionary<string, IModuleFactory> Factories = new();
    public ModuleFactoryRegister()
    {
        this.RegisterFactories();
    }
    private void RegisterFactories()
    {
        // Получаем все типы из текущей сборки 
        var factoryTypes =
            from t in
                Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
            where t.GetCustomAttribute<ModuleFactoryAttribute>() != null
                  &&
                  typeof(IModuleFactory).IsAssignableFrom(t)
            select t;
        // Создаем экземпляры и регистрируем в словаре 
        foreach (var type in factoryTypes)
        {
            var attribute = type.GetCustomAttribute<ModuleFactoryAttribute>();
            var instance = (IModuleFactory)Activator.CreateInstance(type);
            Factories[attribute.Type] = instance;
        }
    }

    public IModuleFactory? GetFactory(string type)
    {
        return Factories.TryGetValue(type, out var factory) ? factory : null;
    }
}