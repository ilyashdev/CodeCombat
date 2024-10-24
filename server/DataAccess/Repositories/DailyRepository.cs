using CodeCombat.DataAccess;
using CodeCombat.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

public class DailyRepository
{
    private readonly CCDbContext _context;
    private DailyEntity? _dailyNow;
        public DailyRepository(CCDbContext context)
        {
            _context = context;
        }
            public async Task AddDaily(DailyEntity daily)
        {
            if(await _context.Dailys.AsNoTracking().FirstAsync(s => s.Daytime == daily.Daytime) != null)
            throw new Exception("Дейлик на эту дату уже существует");

            await _context.Dailys.AddAsync(daily);
            await _context.SaveChangesAsync();
        }
        
        public async Task<DailyEntity?> GetDaily()
        {
            var dateNow = DateOnly.FromDateTime(DateTime.UtcNow);
            if(_dailyNow == null || _dailyNow.Daytime != dateNow)
            {
            var daily = await _context.Dailys
                                        .AsNoTracking()
                                        .FirstAsync(s => s.Daytime == dateNow);
            _dailyNow = daily;
            }
            return _dailyNow;
        }
}