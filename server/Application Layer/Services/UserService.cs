using CodeCombat.Application_Layer.Services.IService;
using CodeCombat.Domain_Layer.Models;
using CodeCombat.Presentation_Layer.Contract;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetProfileAsync(long id)
    {
        return await _userRepository.GetUserAsync(id);
    }

    public async Task<User> GetUserAsync(long id)
    {
        return await _userRepository.GetUserAsync(id);
    }

    public async Task SignUpAsync(SignUpRequest request)
    {
        await _userRepository.SignUpAsync(new User{TelegramId = request.TelegramId,Name = request.Name});
    }
}