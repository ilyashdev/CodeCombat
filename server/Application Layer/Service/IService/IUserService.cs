using CodeCombat.Domain_Layer.Models;
using CodeCombat.Presentation_Layer.Contract;

namespace CodeCombat.Application_Layer.Service;
public interface IUserService
{
    Task<User> GetUserAsync(long telegramId);
    Task SignUpAsync(SignUpRequest request);
}