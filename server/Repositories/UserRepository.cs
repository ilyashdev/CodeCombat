using Microsoft.EntityFrameworkCore;
using CodeCombat.Models;
using CodeCombat.Contracts;

namespace CodeCombat.DataAccess.Repositories
{
    public class UserRepository
    {
        private readonly UserDbContext _context;
        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<User?> FindUserAsync(TInitRequest userData)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Username == userData.username && u.TelegramToken == userData.ttoken);
            return user;
        }

        public async Task AddUserAsync(TInitRequest user)
        {

            await _context.AddAsync(new User(user.id,user.username,user.ttoken));
            await _context.SaveChangesAsync();
        }
    }
}