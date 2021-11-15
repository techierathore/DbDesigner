using Blazored.LocalStorage;
using DbDesigner.Models;
using DbDesigner.UI.Services;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace DbDesigner.UI.Common
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService LocalStorageSvc;
        private readonly IAuthService AuthSvc;

        public CustomAuthStateProvider(ILocalStorageService aLocalStorageSvc, IAuthService aAuthSvc)
        {
            //throw new Exception("CustomAuthenticationStateProviderException");
            LocalStorageSvc = aLocalStorageSvc;
            AuthSvc = aAuthSvc;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var vAccessToken = await LocalStorageSvc.GetItemAsync<string>(AppConstants.AccessKey);

            ClaimsIdentity vIdentity;
            if (vAccessToken != null && vAccessToken != string.Empty)
            {
                AppUser user = await AuthSvc.GetUserByAccessTokenAsync(vAccessToken);
                vIdentity = GetClaimsIdentity(user);
            }
            else
            {
                vIdentity = new ClaimsIdentity();
            }
            var vClaimsPrincipal = new ClaimsPrincipal(vIdentity);
            return await Task.FromResult(new AuthenticationState(vClaimsPrincipal));
        }

        public async Task MarkUserAsAuthenticated(AppUser aLoggedUser)
        {
            await LocalStorageSvc.SetItemAsync(AppConstants.AccessKey, aLoggedUser.AccessToken);
            await LocalStorageSvc.SetItemAsync(AppConstants.RefreshKey, aLoggedUser.RefreshToken);

            var vIdentity = GetClaimsIdentity(aLoggedUser);
            var vClaimsPrincipal = new ClaimsPrincipal(vIdentity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(vClaimsPrincipal)));
        }

        public async Task MarkUserAsLoggedOut()
        {
            await LocalStorageSvc.RemoveItemAsync(AppConstants.RefreshKey);
            await LocalStorageSvc.RemoveItemAsync(AppConstants.AccessKey);

            var vIdentity = new ClaimsIdentity();
            var vUser = new ClaimsPrincipal(vIdentity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(vUser)));
        }

        private ClaimsIdentity GetClaimsIdentity(AppUser aLoggedInUser)
        {
            var vClaimsIdentity = new ClaimsIdentity();

            if (aLoggedInUser.EmailID != null)
            {
                vClaimsIdentity = new ClaimsIdentity(GenerateClaims(aLoggedInUser), "apiauth_type");
            }

            return vClaimsIdentity;
        }

        private IEnumerable<Claim> GenerateClaims(AppUser aLoggedInUser)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.PrimarySid, Convert.ToString(aLoggedInUser.AppUserId)),
                new Claim(ClaimTypes.Name, aLoggedInUser.FullName),
                new Claim(ClaimTypes.Email, aLoggedInUser.EmailID),
                new Claim(ClaimTypes.MobilePhone, aLoggedInUser.MobileNo),
                new Claim(ClaimTypes.Role, aLoggedInUser.Role)
             };
            return claims;
        }
    }
}
