using System.Runtime.InteropServices.JavaScript;
using CodeCombat.Domain_Layer.Models;
using CodeCombat.Domain_Layer.Models.Course.Modules;
using CodeCombat.Presentation_Layer.Contract;

namespace CodeCombat.Application_Layer.Service;
public interface IModuleService
{
    Task PostAsync(Guid id, long TelegramId,ModuleRequest moduleData, int? pos);
    Task<Module> GetAsync(Guid id);
    Task DeleteAsync(Guid id, long TelegramId);
}