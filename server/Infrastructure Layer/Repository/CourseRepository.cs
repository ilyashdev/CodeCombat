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

    public async Task DeleteCourseAsync(long telegramId, Guid id)
    {
        var course = await _context.Courses
            .FirstAsync(c => c.Id == id);
        await _context.Entry(course).Reference(c => c.Creator).LoadAsync();
        if(course.Creator.TelegramId != telegramId)
            throw new Exception("нет прав на выполнение действия");
        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();
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
        var courses = _context.Courses
            .OrderBy(c => c.InFavoriteUser.Count)
            .Where(c => c.Tags.All(t => request.tags.Contains(t)))
            .Skip(CourseOptions.PAGE_SIZE * page)
            .Take(CourseOptions.PAGE_SIZE);
        await courses.ForEachAsync(c => {
            _context.Entry(c).Reference(c => c.Creator).Load();
            _context.Entry(c).Reference(c => c.Comments).Load();
            });
        var courseDto = courses
            .Select(
                c => new CourseDto(
                    c.Id,
                    new UserDto(c.Creator.TelegramId,c.Creator.Name),
                    c.Tags,
                    c.ContentType,
                    c.PublicTime,
                    c.UpUsers.Count,
                    c.DownUsers.Count,
                    (ICollection<ModuleDto>)c.Modules.Select(m => new ModuleDto(m.Name,m.ModuleType))
                    ));
        return await courseDto.ToListAsync();
    }

    public async Task PostCourseAsync(long telegramId, Course postCourse)
    {
        var userEntity = await _context.Users
            .FirstAsync(u => u.TelegramId == telegramId);
        await _context.Entry(userEntity).Collection(c => c.MyContent).LoadAsync();
        userEntity.MyContent.Add(postCourse);
        await _context.SaveChangesAsync();
    }
}