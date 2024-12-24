namespace CodeCombat.Domain_Layer.Models;

public class Result
{
    Guid id {get;set;}
    User? user {get;set;}
    string? text {get;set;}
}