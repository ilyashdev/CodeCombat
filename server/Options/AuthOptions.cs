using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CodeCombat.Options;
public static class AuthOptions
{
    static public readonly string SECRET_KEY = 
        BitConverter.ToString(
            new HMACSHA256(Encoding.UTF8.GetBytes(KEY))
            .ComputeHash(Encoding.UTF8.GetBytes(BOT_TOKEN)));
    static public const string BOT_TOKEN = "";
    static public const string KEY = "WebAppData";
}