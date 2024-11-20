using CodeCombat.DataAccess.Entity;

namespace CodeCombat.DataAccess.Factory;
public class CodeModuleFactory : IModuleFactory
{
    public BaseModuleEntity CreateModule(dynamic data)
    {
        return new CodeEntity
        {
            Name = data.name,
            Title = data.title,
            Description = data.description,
            Input = data.input,
            Output = data.output,
            Examples = data.examples.ToList(),
            Test = data.test.ToList()
        };
    }
}