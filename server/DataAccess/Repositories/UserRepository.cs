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
                .FirstOrDefaultAsync(u => u.TelegramToken == userData.ttoken);
            return user;
        }

        public async Task AddUserAsync(TInitRequest user)
        {

            await _context.Users.AddAsync(new User(user.id,user.username,user.ttoken));
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AddSolution(TInitRequest user, SolutionsEntity solution)
        {
            User? adduser = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == user.username && 
                                     u.Id == user.id &&
                                     u.TelegramToken == user.ttoken);
            if(adduser != null)
            {
            solution.UserId = adduser.Id;
            await _context.Solutions.AddAsync(solution);
            await _context.SaveChangesAsync();
            return true;
            }
            return false;
        }
        
        public async Task<List<SolutionsEntity>> GetSolution(TInitRequest user)
        {
            User? auser = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == user.username && 
                                     u.Id == user.id &&
                                     u.TelegramToken == user.ttoken);
            if(auser != null)
            {
                var soluts = await _context.Solutions
                    .AsNoTracking()
                    .ToListAsync();
                return soluts.Where(s=> (s.UserId == auser.Id)).ToList();
            }
            return null;
        }

        public async Task<List<SolutionsEntity>> GetTopList()
        {
            var soluts = await _context.Solutions
                    .AsNoTracking()
                    .ToListAsync();
            return soluts;
        }
    }
}