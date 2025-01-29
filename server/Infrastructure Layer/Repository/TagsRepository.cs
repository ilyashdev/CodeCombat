using CodeCombat.Domain_Layer.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeCombat.Infrastructure_Layer.Repository;
public class TagsRepository : ITagsRepository
{
    private readonly CcDbContext _context;

    public TagsRepository(CcDbContext context)
    {
        _context = context;
    }

    public async Task AddTagAsync(Tag tag)
    {
        if(_context.Tags.FirstOrDefault(t => t.Name == tag.Name) != null)
            new Exception("this tag exist");
        await _context.Tags.AddAsync(tag);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Tag>> GetContentTagsAsync(ICollection<string> stringTags)
    {
        var addTags = stringTags.Where(t => !_context.Tags.Any(tag => tag.Name == t));
        foreach (var tag in addTags)
        {
            await this.AddTagAsync(new Tag{Name = tag});
        }
        var tags = _context.Tags
            .Where(t => stringTags.Contains(t.Name))
            .ToList();
        return tags;
    }
        public async Task<ICollection<Tag>> GetTagsAsync(ICollection<string> stringTags)
    {
        var tags = _context.Tags.Where(t => stringTags.Contains(t.Name));
        return await tags.ToListAsync();
    }
}