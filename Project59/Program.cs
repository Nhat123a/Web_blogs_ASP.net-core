using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Project59.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("UserdbcontextConnection") ?? throw new InvalidOperationException("Connection string 'UserdbcontextConnection' not found.");



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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "Areas",
    pattern: "{area=Admin}/{controller=Home}/{action=Index}/{id?}");





app.Run();
