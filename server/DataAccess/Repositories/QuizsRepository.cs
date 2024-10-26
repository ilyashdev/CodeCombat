using CodeCombat.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace CodeCombat.DataAccess.Repositories;

public class QuizRepository
{
    private readonly CCDbContext _context;
    public QuizRepository(CCDbContext context)
        {
            _context = context;
        }

    public async Task AddQuiz(QuizEntity quiz)
    {
        await _context.Quizs.AddAsync(quiz);
        await _context.SaveChangesAsync();
    }
    public async Task<List<QuizEntity>> GetQuiz(List<string> tags)
    {
        var quiz =
        await _context.Quizs
            .AsNoTracking()
            .Where(q => tags.Except(q.Tags).Count() == 0)
            .OrderBy(q => q.Like - q.Dislike)
            .ToListAsync();
        return quiz;
    }
}