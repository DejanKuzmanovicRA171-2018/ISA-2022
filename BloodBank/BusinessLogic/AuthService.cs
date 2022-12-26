using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BusinessLogic
{
    public class AuthService : IAuthService
    {
        public string CreateToken(IdentityUser user, string tokenConfig, string Role)
        {
            List<Claim> claims = new()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("role" , Role)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(tokenConfig));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
