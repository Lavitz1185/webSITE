using Microsoft.EntityFrameworkCore;
using webSITE.Repositori.Data;
using webSITE.Repositori.Implementasi;
using webSITE.Repositori.Interface;
using Microsoft.AspNetCore.Identity;
using webSITE.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = "";

if (builder.Environment.IsDevelopment())
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
else
    connectionString = builder.Configuration.GetConnectionString("PublishedConnection");

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddDefaultIdentity<Mahasiswa>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();


builder.Services.AddScoped<IRepositoriMahasiswa, RepositoriMahasiswa>();
builder.Services.AddScoped<IRepositoriFoto, RepositoriFoto>();
builder.Services.AddScoped<IRepositoriKegiatan, RepositoriKegiatan>();

builder.WebHost.UseStaticWebAssets();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Dashboard",
    pattern: "Dashboard/{controller=Home}/{Action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
