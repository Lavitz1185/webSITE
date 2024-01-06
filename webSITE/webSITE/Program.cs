using Microsoft.EntityFrameworkCore;
using webSITE.Repositori.Data;
using webSITE.Repositori.Implementasi;
using webSITE.Repositori.Interface;
using Microsoft.AspNetCore.Identity;
using webSITE.Data;
using webSITE.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddDefaultIdentity<Mahasiswa>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<IdentityContext>();

builder.Services.AddDbContext<IdentityContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IRepositoriMahasiswa, RepositoriMahasiswa>();
builder.Services.AddScoped<IRepositoriFoto, RepositoriFoto>();
builder.Services.AddScoped<IRepositoriKegiatan, RepositoriKegiatan>();

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
