using CodeCombat.Application_Layer.Services.IService;
using CodeCombat.Domain_Layer.Models;
using CodeCombat.Domain_Layer.Models.Course;
using CodeCombat.Domain_Layer.Models.Course.Modules;

namespace CodeCombat.Application_Layer.Services;

public class CourseService : ICourseService
{
    public Task DeleteCourseAsync(User user, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task EditCourseAsync(User user, Course changeCourse)
    {
        throw new NotImplementedException();
    }

    public Task<Course> GetCourseAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Course>> GetCourseListAsync(int page)
    {
        throw new NotImplementedException();
    }

    public Task<Module> GetModuleAsync(Guid courseId, int moduleId)
    {
        throw new NotImplementedException();
    }

    public Task PostCourseAsync(User user, Course postCourse)
    {
        throw new NotImplementedException();
    }
}