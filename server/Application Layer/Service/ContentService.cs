using CodeCombat.Application_Layer.Service;
using CodeCombat.Domain_Layer.Models;
using CodeCombat.Infrastructure_Layer.Repository;
using CodeCombat.Presentation_Layer.Contract;

namespace CodeCombat.Application_Layer.Service;
public class ContentService : IContentService
{
    private readonly IContentRepository _contentRepository;
    private readonly IUserRepository _userRepository;
    public ContentService(
        IContentRepository contentRepository, 
        IUserRepository userRepository)
    {
        _contentRepository = contentRepository;
        _userRepository = userRepository;
    }

    public async Task DeleteAsync(long telegramId, Guid id)
    {
        var user = await _userRepository.GetUserAsync(telegramId);
        await _contentRepository.DeleteContentAsync(user, id);
    }
    public async Task<ICollection<ContentDto>> GetListAsync(string type, int page, ContentListRequest? request)
    {
        return await _contentRepository.GetContentListAsync(type, page, request);
    }
}