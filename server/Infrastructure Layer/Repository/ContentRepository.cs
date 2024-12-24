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
    public async Task<ICollection<ContentDto>> GetContentListAsync(string type, int page, ICollection<string>? stags)
    {
        ICollection<Content> contents;
        if(stags != null)
        {
            var tags = await _tagsRepository.GetTagsAsync(stags);
            foreach (var tag in tags)
            {
                await _context.Entry(tag).Collection(t => t.Contents).LoadAsync();
            }
            contents = tags
                .Select(t => t.Contents)
                .Aggregate((prev, next) => prev.Intersect(next).ToList())
            .Where(c => c.ContentType == type)
            .ToList();
        }
        else
        {
            contents = await _context.Contents
                .Where(c => c.ContentType == type)
                .ToListAsync();
        }
        foreach (var content in contents)
        {
            await _context.Entry(content).Reference(t => t.Creator).LoadAsync();
            await _context.Entry(content).Collection(t => t.UpUsers).LoadAsync();
            await _context.Entry(content).Collection(t => t.DownUsers).LoadAsync();
            await _context.Entry(content).Collection(t => t.Watched).LoadAsync();
        }
        var contentDtos = contents
            .OrderBy(c => c.Watched.Count * (c.UpUsers.Count + 1) / (c.DownUsers.Count + 1))
            .Skip(ContentOptions.PAGE_SIZE*page)
            .Take(ContentOptions.PAGE_SIZE)
            .Select(c => 
            new ContentDto
            (
                c.Id,
                c.Name,
                c.ContentType,
                c.Description,
                new UserDto(c.Creator.TelegramId,c.Creator.Name),
                c.Tags.Select(t => t.Name).ToList(),
                c.PublicTime,
                c.Watched.Count,
                c.UpUsers.Count,
                c.DownUsers.Count
            )
            );
        return contentDtos.ToList();
    }
}