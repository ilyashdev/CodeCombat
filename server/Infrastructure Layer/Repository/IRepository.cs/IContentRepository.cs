using CodeCombat.Domain_Layer.Models;
using CodeCombat.Presentation_Layer.Contract;

namespace CodeCombat.Infrastructure_Layer.Repository;
public interface IContentRepository
{
    
    Task PostContentAsync(long telegramId, Content postContent);
    Task EditContentAsync(long telegramId, Content changeContent);
    Task<ICollection<ContentDto>> GetContentListAsync(string type,int page, ContentListRequest? request);
    Task<Content> GetContentAsync(Guid id);
    Task DeleteContentAsync(long telegramId, Guid id);
}