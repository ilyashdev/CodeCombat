using System.Reflection;
using CodeCombat.Domain_Layer.Factory.Attribute;
using CodeCombat.Presentation_Layer.Contract.Course;
using Module = CodeCombat.Domain_Layer.Models.Course.Modules.Module;

namespace CodeCombat.Domain_Layer.Factory.ModuleFactory;

public abstract class ModuleFactoryBase : IModuleFactory
{
    private static readonly Dictionary<string, IModuleFactory> Factories = new();

    static ModuleFactoryBase()
    {
        RegisterFactories();
    }

    public abstract Module Create(ModuleRecord module);

    private static void RegisterFactories()
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

    public static IModuleFactory? GetFactory(string type)
    {
        return Factories.TryGetValue(type, out var factory) ? factory : null;
    }
}