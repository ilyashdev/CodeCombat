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
        var content = await _context.Contents
            .FirstAsync(c => c.Id == id);
        await _context.Entry(content).Reference(c => c.Creator).LoadAsync();
        if(content.Creator.TelegramId != telegramId)
            throw new Exception("нет прав на выполнение действия");
        _context.Contents.Remove(content);
        await _context.SaveChangesAsync();
    }

    public Task EditContentAsync(long telegramId, Content changeContent)
    {
        throw new NotImplementedException();
    }

    public Task<Content> GetContentAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<ContentDto>> GetContentListAsync(string type, int page, ContentListRequest? request)
    {
        //Переделай все это безобразие
        var contents = _context.Contents
            .OrderBy(c => c.InFavoriteUser.Count)
            .Where(c => c.Tags.All(t => request.tags.Contains(t.Name)))
            .Skip(ContentOptions.PAGE_SIZE * page)
            .Take(ContentOptions.PAGE_SIZE);
        await contents.ForEachAsync(c => {
            _context.Entry(c).Reference(c => c.Creator).Load();
            _context.Entry(c).Reference(c => c.Comments).Load();
            });
        var contentDto = contents
            .Select(
                c => new ContentDto(
                    c.Id,
                    new UserDto(c.Creator.TelegramId,c.Creator.Name),
                    (ICollection<string>)c.Tags.Select(c => c.Name),
                    c.ContentType,
                    c.PublicTime,
                    c.UpUsers.Count,
                    c.DownUsers.Count,
                    (ICollection<CommentDto>)c.Comments
                        .Select(
                            c => 
                            new CommentDto(
                                c.Id,
                                new UserDto(c.Creator.TelegramId,c.Creator.Name),
                                c.Text,
                                c.PublicTime, 
                                null))
                    ));
        return await contentDto.ToListAsync();
    }

    public async Task PostContentAsync(long telegramId, Content postContent)
    {
        var userEntity = await _context.Users
            .Include(u => u.MyContent)
            .FirstAsync(u => u.TelegramId == telegramId);
        userEntity.MyContent.Add(postContent);
        await _context.SaveChangesAsync();
    }
}