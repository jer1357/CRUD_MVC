using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CRUD_MVC_Demo.Models;

var builder = WebApplication.CreateBuilder(args);

// 註冊 `DbContext`
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 註冊 MVC
builder.Services.AddControllersWithViews(); // 如果你是 MVC

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Shippers}/{action=Index}/{id?}"); // 設定首頁到 Shippers

app.Run();