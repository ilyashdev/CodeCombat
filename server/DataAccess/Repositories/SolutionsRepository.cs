using CodeCombat.DataAccess;
using CodeCombat.DataAccess.Entity;
using CodeCombat.Models;

public class SolutionsRepository
{
    private readonly CCDbContext _context;
        public SolutionsRepository(CCDbContext context)
        {
            _context = context;
        }
            public async Task<bool> AddSolution(User user, SolutionsEntity solution)
        {
            return false;
        }
        
        public async Task<List<SolutionsEntity>?> GetSolution()
        {
            return null;
        }

        public async Task<List<SolutionsEntity>> GetTopList()
        {
            return null;
        }
}