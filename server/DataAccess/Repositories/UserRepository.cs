using Microsoft.EntityFrameworkCore;
using CodeCombat.Models;
using CodeCombat.DataAccess.Entity;

namespace CodeCombat.DataAccess.Repositories
{
    public class UserRepository
    {
        private readonly CCDbContext _context;
        public UserRepository(CCDbContext context)
        {
            _context = context;
        }

        public async Task<UserEntity?> FindUserAsync(User userData)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == userData.Id);
            return user;
        }

        public async Task AddUserAsync(User user)
        {

            await _context.Users.AddAsync(new UserEntity{Id = user.Id,Username = user.Username});
            await _context.SaveChangesAsync();
        }
    }
}