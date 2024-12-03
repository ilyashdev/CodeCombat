using CodeCombat.Domain_Layer.Models;

public interface IUserRepository
{
    Task<User> GetUserAsync(long telegramId);
    Task SignUpAsync(User user);
}