using CodeCombat.Domain_Layer.Models;
using CodeCombat.Options;
using CodeCombat.Presentation_Layer.Contract;
using Microsoft.EntityFrameworkCore;

namespace CodeCombat.Infrastructure_Layer.Repository;
public class ContentRepository : IContentRepository
{
    private readonly CcDbContext _context;

    public ContentRepository(CcDbContext context)
    {
        _context = context;
    }

    public async Task DeleteContentAsync(long telegramId, Guid id)
    {
        var user = await _context
            .Users.FirstAsync(u => u.TelegramId == telegramId);
        var content = await _context
            .Contents.FirstAsync(u => u.Id == id);
        if(content.Creator != user)
            throw new Exception("No permissions");
        _context.Contents.Remove(content);
        await _context.SaveChangesAsync();
    }
    public async Task<ICollection<ContentDto>> GetContentListAsync(string type, int page, ContentListRequest request)
    {
        var tags = _context.Tags
            .Where(t => request.tags.Contains(t.Name));
        var contents = tags
            .Select( t => t.Contents)
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
    public async Task<Content> GetContentAsync(Guid id)
    {
        return await _context.Contents
            .AsNoTracking()
            .FirstAsync(c => c.Id == id);
    }

    public async Task PostContentAsync(long telegramId, Content postContent, string tags)
    {
        var user = await _context
            .Users.FirstAsync(u => u.TelegramId == telegramId);
        postContent.Creator = user;
        await _context.Contents.AddAsync(postContent);
        await _context.SaveChangesAsync();
    }
    public async Task EditContentAsync(long telegramId, Content changeContent, string tags)
    {
        var user = await _context
            .Users.FirstAsync(u => u.TelegramId == telegramId);
        var content = await _context
            .Contents.FirstAsync(c => c.Id == changeContent.Id);
        if(content.Creator != user)
            throw new Exception("No permissions");
        content.Name = changeContent.Name;
        content.Tags = changeContent.Tags;
        await _context.SaveChangesAsync();
    }
}