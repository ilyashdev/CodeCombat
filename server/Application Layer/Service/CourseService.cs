
using CodeCombat.Domain_Layer.Models;
using CodeCombat.Domain_Layer.Models.Course;
using CodeCombat.Infrastructure_Layer.Repository;
using CodeCombat.Presentation_Layer.Contract;
using CodeCombat.Presentation_Layer.Contract.Course;

namespace CodeCombat.Application_Layer.Service;
public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly IUserRepository _userRepository;
    private readonly ITagsRepository _tagsRepository;

    public CourseService(
        ICourseRepository courseRepository,
        IUserRepository userRepository,
        ITagsRepository tagsRepository)
    {
        _courseRepository = courseRepository;
        _userRepository = userRepository;
        _tagsRepository = tagsRepository;
    }

    public Task EditAsync(long telegramId, ContentRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<CourseDto> GetAsync(Guid id, long telegramId)
    {
        return await _courseRepository.GetAsync(id, new User{TelegramId = telegramId});
    }

    public async Task PostAsync(long telegramId, ContentRequest request)
    {
        var user = await _userRepository.GetUserAsync(telegramId);
        var tags = await _tagsRepository.GetContentTagsAsync(request.Tags);
        var course = new Course
        {
            Name = request.Name,
            Creator = user,
            Tags = tags,
            Description = request.Description
        };
        await _courseRepository.PostAsync(course);
    }
}