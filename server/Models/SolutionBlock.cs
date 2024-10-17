using CodeCombat.Contracts;

namespace CodeCombat.Models;

public class SolutionBlock
{
    public DateOnly day{ get; init; }
    public List<SolutionUnit> daySolutions{ get; init; }
    
    public SolutionBlock()
    {
        day = DateOnly.FromDateTime(DateTime.UtcNow);
        daySolutions = new List<SolutionUnit>();
    }
}