using CodeCombat.Domain_Layer.Models;
using CodeCombat.Domain_Layer.Models.Course;
using CodeCombat.Presentation_Layer.Contract;
using CodeCombat.Presentation_Layer.Contract.Course;

namespace CodeCombat.Infrastructure_Layer.Repository;

public interface ICourseRepository
{
    Task PostCourseAsync(long telegramId, Course postCourse);
    Task EditCourseAsync(long telegramId, Course changeCourse);
    Task<Course> GetCourseAsync(Guid id);
}