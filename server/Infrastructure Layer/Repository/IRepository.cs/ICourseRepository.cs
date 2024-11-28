using CodeCombat.Contract;
using CodeCombat.Model;

namespace CodeCombat.DataAccess.Repository;
public interface ICourseRepository
{
    Task<CourseDto> GetCourseListAsync(int Page);
    Task<Course> GetCourseAsync(Guid Id);
    Task<Module> GetModuleAsync(Guid CourseId, int ModuleId);
    Task PostCourseAsync(User user,Course PostCourse);
    Task DeleteCourseAsync(User user,Guid Id);
    Task EditCourseAsync(User user,Course ChangeCourse);
}