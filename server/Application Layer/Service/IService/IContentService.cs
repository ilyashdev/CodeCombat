using CodeCombat.Domain_Layer.Models;
using CodeCombat.Presentation_Layer.Contract;

namespace CodeCombat.Application_Layer.Service;
public interface IContentService
{
    Task<ICollection<ContentDto>> GetListAsync(string type,int page, ICollection<string>? tags);
    Task DeleteAsync(long telegramId, Guid id);
}
