using Microsoft.AspNetCore.Identity;

namespace BusinessLogic.Interfaces
{
    public interface IUsersService : IBaseService<IdentityUser>
    {
        Task Create(IdentityUser identityUser, string password);
        Task<IdentityUser> GetUser(string Id);
    }
}
