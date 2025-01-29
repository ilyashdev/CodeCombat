using System.Security.Cryptography;
using System.Text;

namespace CodeCombat.Application_Layer.Service;
public class TelegramValidate : IValidateService
{
    private const string BotToken = "YOUR_BOT_TOKEN";

    public bool Validate(Dictionary<string, string> data)
    {
        if (!data.TryGetValue("auth_date", out string authDate) ||
            !data.TryGetValue("hash", out string hash) ||
            !data.TryGetValue("user", out string user))
        {
            return false;
        }
        SortedDictionary<string, string> sortedParams = new SortedDictionary<string, string>(data);
        sortedParams.Remove("hash");
        StringBuilder dataString = new StringBuilder();
        foreach (var param in sortedParams)
        {
            dataString.Append($"{param.Key}={param.Value}\n");
        }
        using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(BotToken)))
        {
            byte[] hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(dataString.ToString().TrimEnd('\n')));
            string computedHash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            return computedHash == hash && (DateTimeOffset.UtcNow.ToUnixTimeSeconds() - Convert.ToInt64(authDate) < 86400);
        }
    }
}
