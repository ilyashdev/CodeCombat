using CodeCombat.Domain_Layer.Models;
using CodeCombat.Presentation_Layer.Contract;

namespace CodeCombat.Infrastructure_Layer.Repository;
public interface IContentRepository
{
    Task<ICollection<ContentDto>> GetContentListAsync(string type,int page, ContentListRequest? request);
    Task DeleteContentAsync(long telegramId, Guid id);
    Task PostContentAsync(long telegramId, Content postContent, string tags);
    Task EditContentAsync(long telegramId, Content changeContent, string tags);
    Task<Content> GetContentAsync(Guid id);
}