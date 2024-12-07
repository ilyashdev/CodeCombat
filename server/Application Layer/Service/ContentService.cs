using CodeCombat.Application_Layer.Service.IService;
using CodeCombat.Domain_Layer.Models;
using CodeCombat.Presentation_Layer.Contract;

namespace CodeCombat.Application_Layer.Service;
public class ContentService : IContentService
{
    private readonly IContentService _contentService;

    public ContentService(IContentService contentService)
    {
        _contentService = contentService;
    }

    public async Task DeleteContent(long telegramId, Guid id)
    {
        await _contentService.DeleteContent(telegramId, id);
    }

    public Task EditContentAsync(long telegramId, ContentRequest request)
    {

    }

    public async Task<Content> GetContentAsync(Guid id)
    {
        return await _contentService.GetContentAsync(id);
    }

    public async Task<ICollection<ContentDto>> GetContentList(long telegramId, string type, int page)
    {
        return await _contentService.GetContentList(telegramId,type,page);
    }

    public Task PostContentAsync(long telegramId, ContentRequest request)
    {
        throw new NotImplementedException();
    }
}