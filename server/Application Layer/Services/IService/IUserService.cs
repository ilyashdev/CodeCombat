using CodeCombat.Domain_Layer.Models;
using CodeCombat.Presentation_Layer.Contract;

namespace CodeCombat.Application_Layer.Services.IService;

public interface IUserService
{
    Task<User> GetUserAsync(long id);
    Task<User> GetProfileAsync(long id);
    Task SignUpAsync(SignUpRequest request);
}