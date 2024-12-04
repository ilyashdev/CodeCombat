using CodeCombat.Domain_Layer.Models.Course;
using Microsoft.EntityFrameworkCore;

namespace CodeCombat.Infrastructure_Layer.Repository;
public class CourseRepository : ICourseRepository
{
    private readonly CcDbContext _context;

    public CourseRepository(CcDbContext context)
    {
        _context = context;
    }

    public async Task EditCourseAsync(long telegramId, Course changeCourse)
    {
        var user = await _context
            .Users.FirstAsync(u => u.TelegramId == telegramId);
        var content = await _context
            .Contents.FirstAsync(c => c.Id == changeCourse.Id);
        if(content.Creator != user)
            throw new Exception("No permissions");
    }

    public async Task<Course> GetCourseAsync(Guid id)
    {
        return await _context.Courses
            .AsNoTracking()
            .FirstAsync(c => c.Id == id);
    }

    public async Task PostCourseAsync(long telegramId, Course postCourse)
    {
        var user = await _context
            .Users.FirstAsync(u => u.TelegramId == telegramId);
        postCourse.Creator = user;
        await _context.Courses.AddAsync(postCourse);
        await _context.SaveChangesAsync();
    }
}