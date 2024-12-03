using CodeCombat.Application_Layer.Services.IService;
using CodeCombat.Domain_Layer.Models;
using CodeCombat.Domain_Layer.Models.Course;
using CodeCombat.Domain_Layer.Models.Course.Modules;
using CodeCombat.Infrastructure_Layer.Repository;
using CodeCombat.Infrastructure_Layer.Repository.IRepository.cs;
using CodeCombat.Presentation_Layer.Contract;
using CodeCombat.Presentation_Layer.Contract.Course;

namespace CodeCombat.Application_Layer.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task DeleteCourseAsync(long TelegramId, Guid id)
    {
        await _courseRepository.DeleteCourseAsync(TelegramId,id);
    }
    public async Task EditCourseAsync(long TelegramId, ContentRequest request)
    {
        var course = new Course
        {
            Name = request.Name,
            ContentType = request.ContentType,
            Tags = request.Tags
        };
        await _courseRepository.EditCourseAsync(TelegramId,course);
    }
    public async Task<Course> GetCourseAsync(Guid id)
    {
        return await _courseRepository.GetCourseAsync(id);
    }
    public async Task<ICollection<CourseDto>> GetCourseListAsync(int page, CourseListRequest request)
    {
        return await _courseRepository.GetCourseListAsync(page, request);
    }

    public async Task PostCourseAsync(long TelegramId, ContentRequest request)
    {
        var course = new Course
        {
            Name = request.Name,
            ContentType = request.ContentType,
            Tags = request.Tags
        };
        await _courseRepository.PostCourseAsync(TelegramId,course);
    }
}