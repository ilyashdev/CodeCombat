using CodeCombat.DataAccess.Entity;

namespace CodeCombat.DataAccess.Factory;
public class FlashCardModuleFactory : IModuleFactory
{
    public BaseModuleEntity CreateModule(dynamic data)
    {

        return new FlashCardEntity
        {
            Name = data.name,
            Cards = ((IEnumerable<dynamic>)data.cards).Select( c => ((string)c.q,(string)c.aswr)).ToList()
        };
    }
}