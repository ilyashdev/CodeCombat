using CodeCombat.Domain_Layer.Models;
using CodeCombat.Presentation_Layer.Contract;

namespace CodeCombat.Application_Layer.Services.IService;
public interface IContentService
{
    Task<ICollection<ContentDto>> GetContentListAsync(string type, int page, ContentListRequest? request);
    Task<Content> GetContentAsync(string type,Guid id);
    Task PostContentAsync(long TelegramId, ContentRequest request);
    Task DeleteContentAsync(long TelegramId, Guid id);
    Task EditContentAsync(long TelegramId, ContentRequest request);
}