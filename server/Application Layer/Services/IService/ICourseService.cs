using CodeCombat.Model;

namespace CodeCombat.Service;
public interface ICourseService
{
    Task<ICollection<Course>> GetCourseListAsync(int Page);
    Task<Course> GetCourseAsync(Guid Id);
    Task<Module> GetModuleAsync(Guid CourseId, int ModuleId);
    Task PostCourseAsync(User user,Course PostCourse);
    Task DeleteCourseAsync(User user,Guid Id);
    Task EditCourseAsync(User user,Course ChangeCourse);
}