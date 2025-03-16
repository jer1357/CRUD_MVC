using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CRUD_MVC_Demo.Models;
using CRUD_MVC_Demo.Repositories;
using CRUD_MVC_Demo.Services;

var builder = WebApplication.CreateBuilder(args);

// 取得連線字串
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 🔹 註冊 `DbContext`（改為 `NorthwindContext`）
builder.Services.AddDbContext<NorthwindContext>(options =>
    options.UseSqlServer(connectionString));

// 🔹 註冊 Repository 層（資料存取）
builder.Services.AddScoped<IShipperRepository, ShipperRepository>();

// 🔹 註冊 Service 層（商業邏輯）
builder.Services.AddScoped<IShipperService, ShipperService>();

// 🔹 註冊 MVC 支援
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 🔹 啟用錯誤處理（僅限開發環境）
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// 🔹 中介軟體（Middleware）
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication(); // 若有身份驗證（登入）
app.UseAuthorization();

// 🔹 設定首頁到 `Shippers`
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Shippers}/{action=Index}/{id?}");

// 🔹 支援 API
app.MapControllers();

app.Run();