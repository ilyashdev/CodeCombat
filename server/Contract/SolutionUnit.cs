namespace CodeCombat.Contracts;

public record SolutionUnit(TimeOnly time, string code, string contest,float runtime, float mem);