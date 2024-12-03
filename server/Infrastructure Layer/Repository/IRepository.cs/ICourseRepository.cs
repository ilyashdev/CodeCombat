using CodeCombat.Domain_Layer.Models;
using CodeCombat.Domain_Layer.Models.Course;
using CodeCombat.Presentation_Layer.Contract;
using CodeCombat.Presentation_Layer.Contract.Course;

namespace CodeCombat.Infrastructure_Layer.Repository.IRepository.cs;

public interface ICourseRepository
{
    Task<ICollection<CourseDto>> GetCourseListAsync(int page, CourseListRequest? request);
    Task<Course> GetCourseAsync(Guid id);
    Task PostCourseAsync(long telegramId, Course postCourse);
    Task DeleteCourseAsync(long telegramId, Guid id);
    Task EditCourseAsync(long telegramId, Course changeCourse);
}