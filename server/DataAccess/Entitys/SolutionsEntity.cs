using System.ComponentModel.DataAnnotations.Schema;
namespace CodeCombat.DataAccess.Entity;


public class SolutionsEntity
{
    public long Id{ get; set; }
    public UserEntity? user{ get; set; }
    public DateTime daytime{ get; init; } = DateTime.UtcNow;
    public string Code{ get; set; } = string.Empty;
    public double? Runtime{ get; set; }
    public string Status{ get; set; } = string.Empty;
    public string LangType{ get; set; } = string.Empty;
}