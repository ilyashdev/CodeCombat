namespace CodeCombat.DataAccess.Entity;
public class CourseEntity : BaseContentEntity
{
    public List<BaseModuleEntity> Modules = new List<BaseModuleEntity>();
}