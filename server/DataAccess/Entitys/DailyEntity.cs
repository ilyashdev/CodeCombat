using System.ComponentModel.DataAnnotations.Schema;
namespace CodeCombat.DataAccess.Entity;


public class DailyEntity
{
    public long Id{ get; set; }
    public DateTime Daytime{ get; init; }
    public string Title{ get; set; } = string.Empty;
    public string Description{ get; set; } = string.Empty;
    public string Input{ get; set; } = string.Empty;
    public string Output{ get; set; } = string.Empty;
    public List<TestEntity> Exemples {get; set;} = new List<TestEntity>();
    public List<TestEntity> Test {get; set;} = new List<TestEntity>();
}