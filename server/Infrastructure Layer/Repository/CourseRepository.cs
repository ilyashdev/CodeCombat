using System.Reflection;
using CodeCombat.Domain_Layer.Models;
using CodeCombat.Domain_Layer.Models.Course;
using CodeCombat.Infrastructure_Layer.Repository.IRepository.cs;
using CodeCombat.Options;
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

    public async Task EditCourseAsync(long telegramId, Course changeCourse)
    {
        var course = await _context.Courses
            .FirstAsync(c => c.Id == changeCourse.Id);
        await _context.Entry(course).Reference(c => c.Creator).LoadAsync();
        if(course.Creator.TelegramId != telegramId)
            throw new Exception("нет прав на выполнение действия");
        course.Name = changeCourse.Name;
        course.Tags = changeCourse.Tags;
        await _context.SaveChangesAsync();
    }

    public async Task<Course> GetCourseAsync(Guid id)
    {
        var course = await _context.Courses
            .AsNoTracking()
            .FirstAsync(c => c.Id == id);
        return course;
    }

    public async Task<ICollection<CourseDto>> GetCourseListAsync(int page, CourseListRequest? request)
    {
        //Фильтрация?

    }

    public async Task PostCourseAsync(long telegramId, Course postCourse)
    {

    }
}