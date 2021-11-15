using Blazored.LocalStorage;
using DbDesigner.Models;
using DbDesigner.UI.Common;
using DbDesigner.UI.Services;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
                .AddHubOptions(o => { o.MaximumReceiveMessageSize = 10 * 1024 * 1024; })
                .AddCircuitOptions(options => { options.DetailedErrors = true; });

var vAppSettings = new AppSettings()
{
    ServiceBaseAddress = builder.Configuration["ServiceBaseAddress"]
};
builder.Services.AddSingleton(vAppSettings);
builder.Services.AddTransient<ValidateHeaderHandler>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddHttpClient<IAuthService, AuthService>();


builder.Services.AddHttpClient<IManageService<DbDesign>, ManageService<DbDesign>>()
        .AddHttpMessageHandler<ValidateHeaderHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
