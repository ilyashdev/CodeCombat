
using CodeCombat.Application_Layer.Service;
using CodeCombat.Domain_Layer.Models;
using CodeCombat.Domain_Layer.Models.Course.Modules;
using Microsoft.EntityFrameworkCore;

namespace CodeCombat.Infrastructure_Layer.Repository;
public class ModuleRepository : IModuleRepository
{
    private readonly CcDbContext _context;
    private readonly ContentService _contentService;

    public ModuleRepository(CcDbContext context, CourseService courseService)
    {
        _context = context;
    }

    public async Task<Module> GetAsync(Guid id)
    {
        return await _context.Modules.FirstAsync(m => m.ModuleId == id);
    }

    public async Task PostAsync(Guid id, User user, Module module)
    {
        
    }
}