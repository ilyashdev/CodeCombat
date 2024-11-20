using System.Drawing;
using CodeCombat.Contracts;
using CodeCombat.DataAccess.Entity;
using CodeCombat.DataAccess.Factory;
using CodeCombat.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CodeCombat.DataAccess.Repositories;
public class CourseRepository
{
private CCDbContext _context;
private Dictionary<string, IModuleFactory> _moduleFactory = new Dictionary<string, IModuleFactory>();

public CourseRepository(CCDbContext context)
{
    _context = context;
    _moduleFactory["code"] = new CodeModuleFactory();
    _moduleFactory["text"] = new TextModuleFactory();
    _moduleFactory["flashcard"] = new FlashCardModuleFactory(); 
}

public async Task<Guid> CreateCourseAsync(User user, string title, string description, List<string> tags)
{
    var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id); 
    var course = new Entity.CourseEntity{
        User = userEntity, 
        Title = title,
        Desc = description,
        Tags = tags
        };
    await _context.Courses.AddAsync(course);
    await  _context.SaveChangesAsync();
    return course.Id;
}
public async Task AddModuleAsync(Guid courseId,List<dynamic> modules)
{
    var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == courseId);
    if(course == null) throw new Exception("Нет такого курса");
    // course.Modules.AddRange(modules.Select(m =>  
    //     (BaseModuleEntity)_moduleFactory[(string)m.type].CreateModule(m)
    // ));
    course.Modules.Add(new TextEntity{Title = "s", Text="sdsa"});
    _context.Courses.Update(course);
    await _context.SaveChangesAsync();
}

public async Task<List<ContentDto>> GetCourseListAsync() //оптимизировать эту хуйню(пока впадлу)
{
 var CourseDto = await _context.Courses
    .AsNoTracking()
    .Select(
        c => new ContentDto(
            c.Id,
            c.User.Username,
            c.Title,
            c.Desc,
            c.Tags,
            c.Like,
            c.Dislike)
        ).ToListAsync();
    return CourseDto;
}

public async Task<CourseEntity?> GetCourseAsync(Guid Id)
{
return await _context.Courses.FirstOrDefaultAsync(c => c.Id == Id);
}

}