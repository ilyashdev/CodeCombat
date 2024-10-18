using System.ComponentModel.DataAnnotations.Schema;
namespace CodeCombat.DataAccess.Entity;


public class SolutionsEntity
{
    public long Id{ get; set; }
    public long UserId{ get; set; }
    public DateTime daytime{ get; init; } = DateTime.UtcNow;
    public string Code{ get; set; }
    public double? Runtime{ get; set; }
    public string Status{ get; set; }
}