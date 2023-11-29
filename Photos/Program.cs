
using Photos.Core.Interfaces;
using Photos.Core.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IPhoto, PhotoService>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    "default", 
    "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
