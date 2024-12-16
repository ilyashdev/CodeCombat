
using CodeCombat.Application_Layer.Service;
using CodeCombat.Domain_Layer.Models;
using CodeCombat.Domain_Layer.Models.Course.Modules;
using Microsoft.EntityFrameworkCore;

namespace CodeCombat.Infrastructure_Layer.Repository;
public class ModuleRepository : IModuleRepository
{
    private readonly CcDbContext _context;
    public ModuleRepository(CcDbContext context, CourseService courseService)
    {
        _context = context;
    }
    public async Task DeleteAsync(Guid id, User user)
    {
        var module = await _context.Modules.FirstOrDefaultAsync(m => m.ModuleId == id);
        await _context.Entry(module)
            .Reference(c => c.InCourse)
            .LoadAsync();
        await _context.Entry(module.InCourse)
            .Reference(c => c.Creator)
            .LoadAsync();
        if(module.InCourse.Creator.TelegramId != user.TelegramId)
            throw new Exception("no permission");
        _context.Modules.Remove(module);
        await _context.SaveChangesAsync();
    }

    public async Task<Module> GetAsync(Guid id)
    {
        return await _context.Modules.FirstAsync(m => m.ModuleId == id);
    }

    public async Task PostAsync(Guid id, User user, Module module,int? pos)
    {
        var course = await _context.Courses
            .FirstAsync(c => c.Id == id);
        await _context.Entry(course)
            .Reference(c => c.Creator)
            .LoadAsync();
        if(course.Creator.TelegramId != user.TelegramId)
            throw new Exception("No permission");
        await _context.Entry(course)
            .Collection(c => c.Modules)
            .LoadAsync();
        if(pos == null)
            course.Modules.Add(module);
        else
            course.Modules.ToList().Insert(pos.Value, module);
        await _context.SaveChangesAsync();
    }
}