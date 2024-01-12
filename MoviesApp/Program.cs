var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "home",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "about",
    pattern: "about",
    defaults: new { controller = "Home", action = "About" }
    );


app.MapControllerRoute(
    name: "movieList",
    pattern: "movies/list",
    defaults: new { controller = "Movies", action = "List" }
    );

//MapContrellerRoute urldeki yazýlacak alaný belirtir.
app.MapControllerRoute(
    name: "movieList",
    pattern: "movies/details",//urlde tanýmlanacak alan
    defaults: new { controller = "Movies", action = "Details" }
    //defaults: urlde movies/details yazýnca calýþacak alan
    );
app.Run();
