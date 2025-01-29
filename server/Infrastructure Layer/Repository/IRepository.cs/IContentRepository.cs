using CodeCombat.Domain_Layer.Models;
using CodeCombat.Presentation_Layer.Contract;

namespace CodeCombat.Infrastructure_Layer.Repository;
public interface IContentRepository
{
    Task<ICollection<ContentDto>> GetContentListAsync(string type,int page, ICollection<string>? tags);
    Task DeleteContentAsync(User user, Guid id);
}