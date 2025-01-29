using CodeCombat.Domain_Layer.Models;
using CodeCombat.Domain_Layer.Models.Course.Modules;
namespace CodeCombat.Infrastructure_Layer.Repository;
public interface IModuleRepository
{
    Task PostAsync(Guid id, User user,Module module, int? pos);
    Task<Module> GetAsync(Guid id);
    Task DeleteAsync(Guid id, User user);
}