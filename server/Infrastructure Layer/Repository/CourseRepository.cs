using CodeCombat.Domain_Layer.Models;
using CodeCombat.Domain_Layer.Models.Course;
using CodeCombat.Domain_Layer.Models.Course.Modules;
using CodeCombat.Infrastructure_Layer.Repository.IRepository.cs;
using CodeCombat.Presentation_Layer.Contract.Course;

namespace CodeCombat.Infrastructure_Layer.Repository;

public class CourseRepository : ICourseRepository
{
    private CcDbContext _context;

    public CourseRepository(CcDbContext context)
    {
        _context = context;
    }

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

    public Task<CourseDto> GetCourseListAsync(int page)
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