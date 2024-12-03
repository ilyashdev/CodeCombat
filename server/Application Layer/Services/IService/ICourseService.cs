using CodeCombat.Domain_Layer.Models;
using CodeCombat.Domain_Layer.Models.Course;
using CodeCombat.Domain_Layer.Models.Course.Modules;
using CodeCombat.Presentation_Layer.Contract;
using CodeCombat.Presentation_Layer.Contract.Course;

namespace CodeCombat.Application_Layer.Services.IService;

public interface ICourseService
{
    Task<ICollection<CourseDto>> GetCourseListAsync(int page, CourseListRequest request);
    Task<Course> GetCourseAsync(Guid id);
    Task PostCourseAsync(long TelegramId, ContentRequest request);
    Task DeleteCourseAsync(long TelegramId, Guid id);
    Task EditCourseAsync(long TelegramId, ContentRequest request);
}