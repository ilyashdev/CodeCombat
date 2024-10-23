using System.ComponentModel.DataAnnotations.Schema;
namespace CodeCombat.DataAccess.Entity;


public class DailyEntity
{
    public long Id{ get; set; }
    public DateTime daytime{ get; init; };
    public string title{ get; set; }
    public string description{ get; set; }
    public string input{ get; set; }
    public string output{ get; set; }
    public List<TestEntity> exemples {get; set;}
    public List<TestEntity> test {get; set;}
}