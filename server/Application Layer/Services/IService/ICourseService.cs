using CodeCombat.Model;

namespace CodeCombat.Service;
public interface ICourseService
{
    Task<ICollection<Course>> GetCourseListAsync();
    Task<Course> GetCourseAsync();
    Task<Module> GetModuleAsync();

}