using Microsoft.AspNetCore.Identity;

namespace IdentityOAuthServer.Service
{
    public static class UserService
    {
        public static void CreateUser(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
               var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var user = new IdentityUser("dav");
                userManager.CreateAsync(user, "password").GetAwaiter().GetResult(); 
            }
        }
    }
}
