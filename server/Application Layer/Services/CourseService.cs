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
        await _courseRepository.AddModuleAsync(Id, course.Modules.Select(m => JsonConvert.DeserializeObject<dynamic>(m.GetRawText())).ToList());
    }
    public async Task<CourseEntity?> GetCourse(Guid courseId)
    {
        return await _courseRepository.GetCourseAsync(courseId);
    }
    public async Task<List<ContentDto>> GetCourseList()
    {
        return await _courseRepository.GetCourseListAsync();
    }
}