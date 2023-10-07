using efCoreApp.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//DataContext servis olarak eklenecek
//1-Yontem
//builder.Services.AddDbContext<DataContext>(opt =>
//{
//    var config = builder.Configuration;
//    var connectionString= config.GetConnectionString("DefaultConnection");
//    opt.UseSqlite(connectionString);
//});
//2-Yontem
builder.Services.AddDbContext<DataContext>(options=>options.UseSqlite
            (builder.Configuration.GetConnectionString("DefaultConnection")));

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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
