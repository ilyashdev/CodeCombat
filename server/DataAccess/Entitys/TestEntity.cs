using Microsoft.EntityFrameworkCore;

namespace CodeCombat.DataAccess.Entity;
[Owned]
public class TestEntity
{
    public string input {get; set;} = string.Empty;
    public string output {get; set;} = string.Empty;
}