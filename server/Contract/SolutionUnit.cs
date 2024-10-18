namespace CodeCombat.Contracts;

public record SolutionUnit(TimeOnly time, string code,TimeSpan? runtime,string status);