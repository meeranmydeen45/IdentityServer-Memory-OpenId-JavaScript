var builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;

services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute(); 
});

app.Run();
