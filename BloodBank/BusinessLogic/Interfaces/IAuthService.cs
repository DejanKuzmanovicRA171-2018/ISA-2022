using Microsoft.AspNetCore.Identity;

namespace BusinessLogic.Interfaces
{
    public interface IAuthService
    {
        string CreateToken(IdentityUser user, string tokenConfig, string role);
    }
}
