using CodeCombat.Domain_Layer.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CodeCombat.Application_Layer.Providers;
public class JwtProvider
{
        public string GenerateToken(User user)
        {
            Claim[] claims = [new("userId", user.TelegramId.ToString()), new(ClaimTypes.Name,user.Name)];
            var token = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
            );

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue;
        }
}