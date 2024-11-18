using CodeCombat.DataAccess.Repositories;
using CodeCombat.Models;

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

    public async Task<bool> Init(User user)
    {
        if (await _userRepository.FindUserAsync(user) == null){
            await _userRepository.AddUserAsync(user);
            return true;
        }
        return false;
    }
}
