using DbDesigner.Models;

namespace DbDesigner.UI.Services
{
    public interface IAuthService
    {
        Task<AppUser> LoginAsync(SvcData user);
        Task<AppUser> RegisterUserAsync(SvcData user);
        Task<AppUser> GetUserByAccessTokenAsync(string accessToken);
        Task<AppUser> RefreshTokenAsync(RefreshRequest refreshRequest);

    }
}
