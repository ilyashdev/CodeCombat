using CodeCombat.Domain_Layer.Models;
using CodeCombat.Domain_Layer.Models.Course;
using CodeCombat.Domain_Layer.Models.Course.Modules;

namespace CodeCombat.Application_Layer.Services.IService;

public interface ICourseService
{
    Task<ICollection<Course>> GetCourseListAsync(int page);
    Task<Course> GetCourseAsync(Guid id);
    Task<Module> GetModuleAsync(Guid courseId, int moduleId);
    Task PostCourseAsync(User user, Course postCourse);
    Task DeleteCourseAsync(User user, Guid id);
    Task EditCourseAsync(User user, Course changeCourse);
}