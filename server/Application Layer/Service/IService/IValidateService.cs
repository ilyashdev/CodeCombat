namespace CodeCombat.Application_Layer.Service;
public interface IValidateService
{
    bool Validate(Dictionary<string, string> data);
}