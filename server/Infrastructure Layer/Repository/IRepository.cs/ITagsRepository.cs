using CodeCombat.Domain_Layer.Models;

namespace CodeCombat.Infrastructure_Layer.Repository;
public interface ITagsRepository
{
    Task<ICollection<Tag>> GetTagsAsync(ICollection<string> stringTags);
    Task AddTagAsync(Tag tag);
}