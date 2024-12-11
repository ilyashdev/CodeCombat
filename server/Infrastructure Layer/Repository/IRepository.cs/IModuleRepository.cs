using CodeCombat.Domain_Layer.Models;
using CodeCombat.Domain_Layer.Models.Course.Modules;
namespace CodeCombat.Infrastructure_Layer.Repository;
public interface IModuleRepository
{
    Task PostAsync(Guid id, User user,Module module);
    Task<Module> GetAsync(Guid id);
}