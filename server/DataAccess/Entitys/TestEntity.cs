using Microsoft.EntityFrameworkCore;

namespace CodeCombat.DataAccess.Entity;
[Owned]
public class TestEntity
{
    public Guid id{get;set;}
    public string input {get; set;} = string.Empty;
    public string output {get; set;} = string.Empty;
}