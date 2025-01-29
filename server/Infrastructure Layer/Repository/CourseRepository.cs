using CodeCombat.Domain_Layer.Models;
using CodeCombat.Domain_Layer.Models.Course;
using CodeCombat.Presentation_Layer.Contract;
using CodeCombat.Presentation_Layer.Contract.Course;
using Microsoft.EntityFrameworkCore;

namespace CodeCombat.Infrastructure_Layer.Repository;
public class CourseRepository : ICourseRepository
{
    private readonly CcDbContext _context;

    public CourseRepository(CcDbContext context)
    {
        _context = context;
    }

    public async Task EditAsync(Guid id, Course edit)
    {
        var course = await _context.Courses
            .FirstAsync(c => c.Id == id);
        course.Tags = edit.Tags;
        course.Name = edit.Name;
        course.Description = edit.Description;
        await _context.SaveChangesAsync();
    }

    public async Task<CourseDto> GetAsync(Guid id,User watcher)
    {
        var course = await _context.Courses
            .FirstAsync(c => c.Id == id);
        await _context.Entry(course)
            .Reference(c => c.Creator)
            .LoadAsync();
        await _context.Entry(course)
            .Collection(c => c.Modules)
            .LoadAsync();
        await _context.Entry(course)
            .Collection(c => c.Tags)
            .LoadAsync();
        await _context.Entry(course)
            .Collection(c => c.Comments)
            .LoadAsync();
        await _context.Entry(course)
            .Collection(c => c.UpUsers)
            .LoadAsync();
        await _context.Entry(course)
            .Collection(c => c.DownUsers)
            .LoadAsync();    
        await _context.Entry(course)
            .Collection(c => c.Watched)
            .LoadAsync();
        if(course.Watched.FirstOrDefault(u => u.TelegramId == watcher.TelegramId) != null)
        {
            course.Watched.Add(watcher);
            await _context.SaveChangesAsync();
        }
        var userDto = new UserDto(course.Creator.TelegramId,course.Creator.Name);
        ICollection<string> tags = null;
        ICollection<ModuleDto> modules = null;
        if(course.Tags != null)
            tags = course.Tags.Select(t => t.Name).ToList();
        if(course.Modules != null)
            modules = course.Modules.Select(m => new ModuleDto(m.ModuleId, m.Name,m.ModuleType)).ToList();
        var courseDto = new CourseDto(
            course.Id,
            userDto,
            course.Description,
            tags,
            course.ContentType,
            course.PublicTime,
            course.UpUsers.Count,
            course.DownUsers.Count,
            modules
        );
        return courseDto;
    }

    public async Task PostAsync(Course course)
    {
        await _context.Courses.AddAsync(course);
        await _context.SaveChangesAsync();
    }
}