using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;

services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", o =>
    {
        o.Authority = "https://localhost:4000/";
        o.Audience = "apione";
        //o.RequireHttpsMetadata = false;
        //o.TokenValidationParameters = new TokenValidationParameters
        //{
        //    ValidAudience = "apione",
        //    ValidateAudience = true,
        //};
    });

services.AddCors(o =>
{
    o.AddPolicy("AllowAll", p =>
    {
        p.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});


//JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

//services.AddAuthentication(options =>
//{
//    options.DefaultScheme = "Cookies";
//    options.DefaultChallengeScheme = "oidc";
//})
//    .AddCookie("Cookies")
//    .AddOpenIdConnect("oidc", options =>
//    {
//        options.Authority = "https://localhost:4000";

//        options.ClientId = "mvc";
//        options.ClientSecret = "secret";
//        options.ResponseType = "code";

//        options.SaveTokens = true;
//    });

services.AddControllersWithViews();

var app = builder.Build();

app.UseRouting();
app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});
app.Run();
