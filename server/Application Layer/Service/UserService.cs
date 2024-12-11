using CodeCombat.Application_Layer.Service;
using CodeCombat.Domain_Layer.Models;
using CodeCombat.Infrastructure_Layer.Repository;
using CodeCombat.Presentation_Layer.Contract;

namespace CodeCombat.Application_Layer.Service;
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetUserAsync(long telegramId)
    {
        return await _userRepository.GetUserAsync(telegramId);
    }

    public async Task SignUpAsync(SignUpRequest request)
    {
        await _userRepository.SignUpAsync
        (
            new User
            {
                TelegramId = request.TelegramId,
                Name = request.Name
            }
        );
    }
}