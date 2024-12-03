using CodeCombat.Application_Layer.Services.IService;
using CodeCombat.Domain_Layer.Models;
using CodeCombat.Presentation_Layer.Contract;

namespace CodeCombat.Application_Layer.Services;
public class ContentService : IContentService
{
    public Task DeleteContentAsync(long TelegramId, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task EditContentAsync(long TelegramId, ContentRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Content> GetContentAsync(string type, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<ContentDto>> GetContentListAsync(string type, int page, ContentListRequest? request)
    {
        throw new NotImplementedException();
    }

    public Task PostContentAsync(long TelegramId, ContentRequest request)
    {
        throw new NotImplementedException();
    }
}