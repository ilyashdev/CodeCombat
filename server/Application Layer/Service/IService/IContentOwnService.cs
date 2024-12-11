using CodeCombat.Domain_Layer.Models;
using CodeCombat.Presentation_Layer.Contract;

namespace CodeCombat.Application_Layer.Service;
public interface IContentOwnService
{
    Task EditAsync(long telegramId,ContentRequest request);
    Task PostAsync(long telegramId,ContentRequest request);
}