using CodeCombat.Domain_Layer.Models.Course;
using CodeCombat.Presentation_Layer.Contract.Course;

namespace CodeCombat.Infrastructure_Layer.Repository;
public interface ICourseRepository
{
    Task EditAsync(Course course);
    Task PostAsync(Course course);
    Task<CourseDto> GetAsync(Guid id);
}