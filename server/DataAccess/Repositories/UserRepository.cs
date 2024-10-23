using Microsoft.EntityFrameworkCore;
using CodeCombat.Models;
using CodeCombat.Contracts;
using CodeCombat.DataAccess.Entity;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CodeCombat.DataAccess.Repositories
{
    public class UserRepository
    {
        private readonly CCDbContext _context;
        public UserRepository(CCDbContext context)
        {
            _context = context;
        }

        public async Task<User?> FindUserAsync(TInitRequest userData)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == userData.id);
            return user;
        }

        public async Task AddUserAsync(TInitRequest user)
        {

            await _context.Users.AddAsync(new User(user.id,user.username,user.ttoken));
            await _context.SaveChangesAsync();
        }
    }
}