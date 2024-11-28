using CodeCombat.Model;

namespace CodeCombat.Service;
public class CourseService : ICourseService
{
    public Task DeleteCourseAsync(User user, Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task EditCourseAsync(User user, Course ChangeCourse)
    {
        throw new NotImplementedException();
    }

    public Task<Course> GetCourseAsync(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Course>> GetCourseListAsync(int Page)
    {
        throw new NotImplementedException();
    }

    public Task<Module> GetModuleAsync(Guid CourseId, int ModuleId)
    {
        throw new NotImplementedException();
    }

    public Task PostCourseAsync(User user, Course PostCourse)
    {
        throw new NotImplementedException();
    }
}