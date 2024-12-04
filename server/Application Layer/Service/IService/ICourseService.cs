using CodeCombat.Domain_Layer.Models;
using CodeCombat.Domain_Layer.Models.Course;
using CodeCombat.Presentation_Layer.Contract;

namespace CodeCombat.Application_Layer.Service.IService;
public interface ICourseService
{
    Task PostCourseAsync(long telegramId, ContentRequest request);
    Task EditCourseAsync(long telegramId, ContentRequest request);
    Task<Course> GetCourseAsync(Guid id);
}