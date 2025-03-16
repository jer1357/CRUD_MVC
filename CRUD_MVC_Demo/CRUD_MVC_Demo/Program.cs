using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CRUD_MVC_Demo.Models;

var builder = WebApplication.CreateBuilder(args);

// 註冊 `DbContext`
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
;

// 註冊 MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Shippers}/{action=Index}/{id?}"); // 設定首頁到 Shippers

app.Run();