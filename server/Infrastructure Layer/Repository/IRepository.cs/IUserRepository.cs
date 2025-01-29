using CodeCombat.Domain_Layer.Models;
namespace CodeCombat.Infrastructure_Layer.Repository;
public interface IUserRepository
{
    Task<User> GetUserAsync(long telegramId);
    Task SignUpAsync(User user);
}