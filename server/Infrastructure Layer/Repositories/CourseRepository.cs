using System.Drawing;
using CodeCombat.Contracts;
using CodeCombat.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace CodeCombat.DataAccess.Repositories;
public class CourseRepository
{
private CCDbContext _context;

public CourseRepository(CCDbContext context)
{
    _context = context;
}

public async Task<Guid> CreateCourseAsync(UserEntity user, string title, string description, List<string> tags)
{
    var course = new Entity.CourseEntity{
        User = user, 
        Title = title,
        Desc = description,
        Tags = tags
        };
    await _context.Courses.AddAsync(course);
    await  _context.SaveChangesAsync();
    return course.Id;
}
public async Task AddModuleAsync(Guid CourseId,BaseModuleEntity module)
{
    var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == CourseId);
    if(course == null) throw new Exception("Нет такого курса");
    course.Modules.Add(module);
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