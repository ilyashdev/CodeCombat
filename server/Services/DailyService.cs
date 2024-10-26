using CodeCombat.Contracts;
using CodeCombat.DataAccess.Entity;

namespace CodeCombat.Services;

public class DailyService
{
    private readonly DailyRepository _dailyRepository;
    public DailyService(DailyRepository dailyRepository)
    {
        _dailyRepository = dailyRepository;
    }    
    public async Task<DailyEntity?> GetDaily()
    {
        return await _dailyRepository.GetDaily();
    }

    public async Task AddDaily(DailyPostRequest daily)
    {
       await _dailyRepository.AddDaily(new DailyEntity{
                        Daytime = daily.Daytime,
                        Title = daily.Title,
                        Description = daily.Desc,
                        Input = daily.Input,
                        Output = daily.Output,
                        Exemples = daily.Exempl.Select(p => new TestEntity{input = p.Input, output = p.Output}).ToList(),
                        Test = daily.Test.Select(p => new TestEntity{input = p.Input, output = p.Output}).ToList()
                        });
    }
    public async Task<List<DailyEntity>?> GetAllDaily()
    {
        return await _dailyRepository.GetAllDaily();
    }
}