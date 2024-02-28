using Microsoft.EntityFrameworkCore;
using webSITE.DataAccess.Data;
using webSITE.Repositori.Implementasi;
using webSITE.DataAccess.Repositori.Interface;
using Microsoft.AspNetCore.Identity;
using webSITE.Domain;
using webSITE.Configuration;
using webSITE.Services.Contracts;
using webSITE.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = "";

if (builder.Environment.IsDevelopment())
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
else
    connectionString = builder.Configuration.GetConnectionString("PublishedConnection");

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
    options.EnableSensitiveDataLogging(true);
    options.EnableDetailedErrors(true);
});

builder.Services.AddDefaultIdentity<Mahasiswa>
    (
        options =>
        {
            options.SignIn.RequireConfirmedAccount = true;
            options.User.RequireUniqueEmail = true;
            options.Password.RequireDigit = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
        }
    )
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.ConfigureApplicationCookie(option =>
{
    option.AccessDeniedPath = new PathString("/Account/AccessDenied");
    option.LoginPath = new PathString("/Account/Login");
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IRepositoriMahasiswa, RepositoriMahasiswa>();
builder.Services.AddScoped<IRepositoriFoto, RepositoriFoto>();
builder.Services.AddScoped<IRepositoriKegiatan, RepositoriKegiatan>();
builder.Services.AddScoped<IRepositoriMahasiswaFoto, RepositoriMahasiswaFoto>();
builder.Services.AddScoped<IRepositoriPesertaKegiatan, RepositoriPesertaKegiatan>();

builder.Services.AddTransient<IMailService, MailService>();

builder.Services.AddSingleton<INotificationService, NotificationService>();

builder.WebHost.UseStaticWebAssets();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/LaporError");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Dashboard",
    pattern: "Dashboard/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
