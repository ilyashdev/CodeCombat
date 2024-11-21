using CodeCombat.DataAccess.Entity;

namespace CodeCombat.DataAccess.Factory;
public class TextModuleFactory : IModuleFactory
{
    public BaseModuleEntity CreateModule(dynamic data)
    {

        return new TextEntity
        {
            Name = data.name,
            Title = data.title,
            Text = data.text
        };
    }
}