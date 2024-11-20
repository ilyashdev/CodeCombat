using CodeCombat.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
namespace CodeCombat.DataAccess.Repositories;

public class SolutionsRepository
{
    private readonly CCDbContext _context;
        public SolutionsRepository(CCDbContext context)
        {
            _context = context;
        }
            public async Task AddSolution(SolutionEntity solution)
        {
            await _context.Solutions.AddAsync(solution);
            await _context.SaveChangesAsync();
        }
        
        public async Task<List<SolutionEntity>?> GetSolution(UserEntity user)
        {
            var solutions = await _context.Solutions
                                        .AsNoTracking()
                                        .Where(s => s.User == user)
                                        .ToListAsync();
            return solutions;
        }

        public async Task<List<SolutionEntity>?> GetTopList()
        {
            var dateNow = DateOnly.FromDateTime(DateTime.UtcNow);
            var solutions = 
            await _context
            .Solutions
            .AsNoTracking()
            .Where(s => s.Runtime > 0 && DateOnly.FromDateTime(s.Daytime) == dateNow)
            .GroupBy(x => x.User)
            .Select(x => x.First())
            .OrderBy(s => s.Runtime)
            .ToListAsync();
            return solutions;
        }
}