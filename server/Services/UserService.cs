using CodeCombat.Contracts;
using CodeCombat.DataAccess.Repositories;

namespace CodeCombat.Services;

public class UserService
{

    private readonly IWebHostEnvironment _env;
    private readonly UserRepository _userRepository;
    public UserService(IWebHostEnvironment env, UserRepository userRepository)
    {
        _env = env;
        _userRepository = userRepository;
    }

    public async Task TInit(TInitRequest userData)
    {
        var user = await _userRepository.FindUserAsync(userData);
        if (user == null){
            await _userRepository.AddUserAsync(userData);
        }
    }
}
