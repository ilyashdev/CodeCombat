using CodeCombat.Domain_Layer.Models;
using Microsoft.EntityFrameworkCore;
namespace CodeCombat.Infrastructure_Layer.Repository;

public class UserRepository : IUserRepository
{
    private readonly CcDbContext _context;

    public UserRepository(CcDbContext context)
    {
        _context = context;
    }
    public async Task<User> GetUserAsync(long telegramId)
    {
        return await _context.Users.FirstAsync(u => u.TelegramId == telegramId);
    }

    public async Task SignUpAsync(User user)
    {
        if(await _context.Users.FirstOrDefaultAsync(u => u.TelegramId == user.TelegramId) != null)
            throw new Exception("user is exist");
            
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }
}