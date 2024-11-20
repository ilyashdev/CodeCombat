namespace CodeCombat.DataAccess.Entity;

public class FlashCardEntity : BaseModuleEntity
{
    public List<(string, string)> Cards = new List<(string, string)>();
}