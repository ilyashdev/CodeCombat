using System.Text.Json.Nodes;
using CodeCombat.Domain_Layer.Factory.ModuleFactory;
using CodeCombat.Domain_Layer.Models.Course.Modules;
using CodeCombat.Infrastructure_Layer.Repository;
using CodeCombat.Presentation_Layer.Contract;

namespace CodeCombat.Application_Layer.Service;
public class ModuleService : IModuleService
{
    private readonly IModuleRepository _moduleRepository;
    private readonly ModuleFactoryRegister _fabrics;
    private readonly IUserRepository _userRepository;

    public ModuleService(IModuleRepository moduleRepository, ModuleFactoryRegister fabrics, IUserRepository userRepository)
    {
        _moduleRepository = moduleRepository;
        _fabrics = fabrics;
        _userRepository = userRepository;
    }

    public Task DeleteAsync(Guid id, long TelegramId)
    {
        throw new NotImplementedException();
    }

    public async Task<Module> GetAsync(Guid id)
    {
        return await _moduleRepository.GetAsync(id);
    }

    public async Task PostAsync(Guid id, long TelegramId, ModuleRequest moduleData, int? pos)
    {
        var user = await _userRepository.GetUserAsync(TelegramId);
        var module = _fabrics.GetFactory(moduleData.ModuleType).Create(moduleData);
        await _moduleRepository.PostAsync(id,user,module,pos);
    }
    public async Task TestAsync(Guid id, long TelegramId, int? pos, JsonObject prop)
    {
        
    }
}