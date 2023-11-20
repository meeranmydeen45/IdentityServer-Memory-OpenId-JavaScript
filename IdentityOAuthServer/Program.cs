using IdentityOAuthServer;
using IdentityOAuthServer.DbContext;
using IdentityOAuthServer.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;


services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("Memory"));

services.AddIdentity<IdentityUser, IdentityRole>(config =>
{
    config.Password.RequiredLength = 4;
    config.Password.RequireDigit = false;
    config.Password.RequireLowercase = false;
    config.Password.RequireUppercase = false;
    config.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

services.ConfigureApplicationCookie(config =>
{
    config.Cookie.Name = "MyApple.Cookie";
    config.LoginPath = "/Auth/Login";
});


services.AddIdentityServer()
      .AddAspNetIdentity<IdentityUser>()
      .AddInMemoryIdentityResources(Configuration.IdentityResources)
      .AddInMemoryApiResources(Configuration.GetApisResource)
      .AddInMemoryApiScopes(Configuration.GetApis)
      .AddInMemoryClients(Configuration.GetClients)
      .AddDeveloperSigningCredential();


services.AddControllersWithViews();

var app = builder.Build();

app.CreateUser();
app.UseIdentityServer();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();
