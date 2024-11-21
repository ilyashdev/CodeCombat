using System.ComponentModel.DataAnnotations.Schema;
namespace CodeCombat.DataAccess.Entity;


public class SolutionEntity
{
    public long Id{ get; set; }
    public UserEntity? User{ get; set; }
    public DateTime Daytime{ get; init; } = DateTime.UtcNow;
    public string Code{ get; set; } = string.Empty;
    public double? Runtime{ get; set; }
    public string Status{ get; set; } = string.Empty;
    public string LangType{ get; set; } = string.Empty;
}