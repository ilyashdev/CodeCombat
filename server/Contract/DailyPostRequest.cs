namespace CodeCombat.Contracts;

public record DailyPostRequest(string Title, DateOnly Daytime, string Desc,string Input, string Output, List<Test> Exempl, List<Test> Test);