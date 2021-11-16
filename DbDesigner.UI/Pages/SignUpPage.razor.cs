using DbDesigner.Models;
using DbDesigner.UI.Common;
using DbDesigner.UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Text.Json;

namespace DbDesigner.UI.Pages
{
    public partial class SignUpPage : ComponentBase
    {
        public SvcData SignUpDetails { get; set; }
        public AppUser PageObj { get; set; }
        public string SignUpMesssage { get; set; }
        [Inject]
        public AuthenticationStateProvider AuthStateProvider { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IAuthService AuthSvc { get; set; }
        private AppUser vValidatedUser;
        protected override Task OnInitializedAsync()
        {
            PageObj = new AppUser();
            return base.OnInitializedAsync();
        }

        private async Task<bool> RegisterUser()
        {
            PageObj.Role = AppConstants.AppUseRole;
            PageObj.IsVerified = true;
            SignUpDetails = new SvcData()
            { ComplexData = JsonSerializer.Serialize(PageObj) };

            vValidatedUser = await AuthSvc.RegisterUserAsync(SignUpDetails);

            if (vValidatedUser.EmailID != null)
            {
                await ((CustomAuthStateProvider)AuthStateProvider).MarkUserAsAuthenticated(vValidatedUser);
                NavigationManager.NavigateTo("/");
            }
            else
            {
                SignUpMesssage = "Invalid username or password";
            }

            return await Task.FromResult(true);
        }
    }
}
