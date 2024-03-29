using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

// SQLite veritaban� ba�lant�s�n� ekleyin
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Uygulama a��ld���nda Default olarak HomeController.cs'teki Index �al���r
// Fakat controller ve action dinamik rota yani URL'de diyelim ki about yazd�m uygulama about sayfas�n� a�ar
app.Run();
