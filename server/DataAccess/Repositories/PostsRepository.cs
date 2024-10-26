using CodeCombat.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace CodeCombat.DataAccess.Repositories;

public class PostRepository
{
    private readonly CCDbContext _context;
    public PostRepository(CCDbContext context)
        {
            _context = context;
        }

    public async Task AddPost(PostEntity Post)
    {
        await _context.Posts.AddAsync(Post);
        await _context.SaveChangesAsync();
    }
    public async Task<List<PostEntity>> GetPost(List<string> tags)
    {
        var Post =
        await _context.Posts
            .AsNoTracking()
            .Where(q => tags.Except(q.Tags).Count() == 0)
            .OrderBy(q => q.Like - q.Dislike)
            .ToListAsync();
        return Post;
    }
}