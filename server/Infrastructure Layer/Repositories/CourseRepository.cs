using System.Drawing;
using CodeCombat.Contracts;
using CodeCombat.DataAccess.Entity;
using CodeCombat.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CodeCombat.DataAccess.Repositories;
public class CourseRepository
{
private CCDbContext _context;


public CourseRepository(CCDbContext context)
{
    _context = context;
}

public async Task<Guid> CreateCourseAsync(User user, string title, string description, List<string> tags)
{
    var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id); 
    var course = new CourseEntity{
        User = userEntity, 
        Title = title,
        Desc = description,
        Tags = tags,
        };
    await _context.Courses.AddAsync(course);
    await  _context.SaveChangesAsync();
    await _context.Courses.LoadAsync();
    return course.Id;
}
public async Task AddModuleAsync(Guid courseId,List<Module>? modules)
{
    var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == courseId);
    if(course == null) throw new Exception("Нет такого курса");
    course.Modules.AddRange(modules.Select(m => new ModuleEntity{Name = m.Name, Type = m.Type ,Data = m.Data}));

    _context.Courses.Update(course);
    await _context.SaveChangesAsync();
    await _context.Entry(course).Collection(c => c.Modules).LoadAsync();
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
return await _context.Courses
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == Id);
}

}