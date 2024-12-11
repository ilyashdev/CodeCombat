using CodeCombat.Presentation_Layer.Contract.Course;

namespace CodeCombat.Application_Layer.Service;
public interface ICourseService : IContentOwnService
{  
    Task<CourseDto> GetAsync(Guid id);
}