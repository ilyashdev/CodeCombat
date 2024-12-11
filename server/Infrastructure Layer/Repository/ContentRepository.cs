using CodeCombat.Domain_Layer.Models;
using CodeCombat.Options;
using CodeCombat.Presentation_Layer.Contract;
using Microsoft.EntityFrameworkCore;

namespace CodeCombat.Infrastructure_Layer.Repository;
public class ContentRepository : IContentRepository
{
    private readonly CcDbContext _context;
    private readonly ITagsRepository _tagsRepository;

    public ContentRepository(CcDbContext context, ITagsRepository tagsRepository)
    {
        _context = context;
        _tagsRepository = tagsRepository;
    }

    public async Task DeleteContentAsync(User user, Guid id)
    {
        var content = await _context
            .Contents.FirstAsync(u => u.Id == id);
        if(content.Creator != user)
            throw new Exception("No permissions");
        _context.Contents.Remove(content);
        await _context.SaveChangesAsync();
    }
    public async Task<ICollection<ContentDto>> GetContentListAsync(string type, int page, ContentListRequest? request)
    {
        var tags = await _tagsRepository.GetTagsAsync(request.tags);
        var contents = tags
            .Select(t => t.Contents)
            .Aggregate((prev, next) => prev.Intersect(next).ToList());
        var contentDtos = contents
            .OrderBy(c => c.UpUsers.Count - c.DownUsers.Count)
            .Skip(ContentOptions.PAGE_SIZE*page)
            .Take(ContentOptions.PAGE_SIZE)
            .Select(c => 
            new ContentDto
            (
                c.Id,
                new UserDto(c.Creator.TelegramId,c.Name),
                c.Tags.Select(t => t.Name).ToList(),
                c.PublicTime,
                c.UpUsers.Count,
                c.DownUsers.Count
            )
            );
        return contentDtos.ToList();
    }
}