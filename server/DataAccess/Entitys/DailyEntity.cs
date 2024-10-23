using System.ComponentModel.DataAnnotations.Schema;
namespace CodeCombat.DataAccess.Entity;


public class DailyEntity
{
    public long Id{ get; set; }
    public DateTime daytime{ get; init; }
    public string title{ get; set; } = string.Empty;
    public string description{ get; set; } = string.Empty;
    public string input{ get; set; } = string.Empty;
    public string output{ get; set; } = string.Empty;
    public List<TestEntity> exemples {get; set;} = new List<TestEntity>();
    public List<TestEntity> test {get; set;} = new List<TestEntity>();
}