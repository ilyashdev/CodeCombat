namespace CodeCombat.DataAccess.Entity;

public class CodeEntity : BaseModuleEntity
{
    public string Title{ get; set; } = string.Empty;
    public string Description{ get; set; } = string.Empty;
    public string Input{ get; set; } = string.Empty;
    public string Output{ get; set; } = string.Empty;
    public List<TestEntity> Examples {get; set;} = new List<TestEntity>();
    public List<TestEntity> Test {get; set;} = new List<TestEntity>();
}