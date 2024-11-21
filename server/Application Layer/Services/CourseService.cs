using CodeCombat.Contracts;
using CodeCombat.DataAccess.Entity;
using CodeCombat.DataAccess.Repositories;
using CodeCombat.Models;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;


namespace CodeCombat.Services;

public class CourseService
{
    private readonly CourseRepository _courseRepository;
    public CourseService(CourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }   
    public async Task AddCourse(User user, CoursePostRequest course)
    {
        var Id = await _courseRepository.CreateCourseAsync(user, course.Title, course.Description, course.Tags);
        if(course.Modules != null)
        await _courseRepository.AddModuleAsync(Id, course.Modules);
    }
    public async Task<CourseResponce> GetCourse(Guid courseId)
    {
        var course = await _courseRepository.GetCourseAsync(courseId);
        return new CourseResponce
        (
            course.User.Username,
            course.Title,
            course.Desc,
            course.Like,
            course.Dislike,
            course.PublicTime,
            course.Tags,
            course.Modules.Select(m => new Module(m.Name,m.Type,m.Data)).ToList()
        );
    }
    public async Task<List<ContentDto>> GetCourseList()
    {
        return await _courseRepository.GetCourseListAsync();
    }
}