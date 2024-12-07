using CodeCombat.Domain_Layer.Models;
using CodeCombat.Presentation_Layer.Contract;

namespace CodeCombat.Application_Layer.Service.IService;
public interface IContentService
{
    Task<ICollection<ContentDto>> GetContentList(long telegramId,string type,int page);
    Task DeleteContent(long telegramId, Guid id);
    Task PostContentAsync(long telegramId, ContentRequest request);
    Task EditContentAsync(long telegramId, ContentRequest request);
    Task<Content> GetContentAsync(Guid id);
}
