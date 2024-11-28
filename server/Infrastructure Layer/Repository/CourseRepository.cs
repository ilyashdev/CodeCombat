using CodeCombat.Contract;
using CodeCombat.Model;
using Microsoft.EntityFrameworkCore;

namespace CodeCombat.DataAccess.Repository;
public class CourseRepository : ICourseRepository
{
    private CCDbContext _context;
    public CourseRepository(CCDbContext context)
    {
        _context = context;
    }
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

    public Task<CourseDto> GetCourseListAsync(int Page)
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