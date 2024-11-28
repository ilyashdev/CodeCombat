using CodeCombat.Domain_Layer.Models;
using CodeCombat.Domain_Layer.Models.Course;
using CodeCombat.Domain_Layer.Models.Course.Modules;
using CodeCombat.Presentation_Layer.Contract.Course;

namespace CodeCombat.Infrastructure_Layer.Repository.IRepository.cs;

public interface ICourseRepository
{
    Task<CourseDto> GetCourseListAsync(int page);
    Task<Course> GetCourseAsync(Guid id);
    Task<Module> GetModuleAsync(Guid courseId, int moduleId);
    Task PostCourseAsync(User user, Course postCourse);
    Task DeleteCourseAsync(User user, Guid id);
    Task EditCourseAsync(User user, Course changeCourse);
}