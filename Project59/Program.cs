using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddAuthentication();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();
app.UseSession();
app.UseAuthorization();
app.MapControllerRoute(
    name: "Areas",
    pattern: "{area=Admin}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.MapControllerRoute(
   name: "Lienhe",
    pattern: "/lien-he",
    defaults: new { controller = "Lienhe", action = "Index" });
app.MapControllerRoute(
   name: "Khuyen Mai",
    pattern: "/khuyen-mai",
    defaults: new { controller = "Khuyenmai", action = "Index" });
app.MapControllerRoute(
   name: "Tin tuc",
    pattern: "/tin-tuc",
    defaults: new { controller = "Tintuc", action = "Index" });
app.Run();
