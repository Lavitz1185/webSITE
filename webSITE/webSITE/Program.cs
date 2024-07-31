using Microsoft.EntityFrameworkCore;
using webSITE.DataAccess.Data;
using webSITE.Repositori.Implementasi;
using webSITE.DataAccess.Repositori.Interface;
using Microsoft.AspNetCore.Identity;
using webSITE.Domain;
using webSITE.Configuration;
using webSITE.Services.Contracts;
using webSITE.Services;
using webSITE.DataAccess.Repositori.Implementasi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = "";

if (builder.Environment.IsDevelopment())
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
else
    connectionString = builder.Configuration.GetConnectionString("PublishedConnection")!;

builder.Services.Configure<MailSettingsOptions>(builder.Configuration.GetSection(MailSettingsOptions.MailSettings));
builder.Services.Configure<PhotoFileSettingsOptions>(builder.Configuration.GetSection(PhotoFileSettingsOptions.PhotoFileSettings));
builder.Services.Configure<PDFFileSettingsOptions>(builder.Configuration.GetSection(PDFFileSettingsOptions.PDFFileSettings));

builder.Services.AddRazorPages().AddSessionStateTempDataProvider();
builder.Services.AddControllersWithViews().AddSessionStateTempDataProvider();
builder.Services.AddSession();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(connectionString)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors();
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
builder.Services.AddScoped<IRepositoriPengumuman, RepositoriPengumuman>();
builder.Services.AddScoped<IRepositoriLomba, RepositoriLomba>();
builder.Services.AddScoped<IRepositoriPesertaLomba, RepositoriPesertaLomba>();
builder.Services.AddScoped<IRepositoriTimLomba, RepositoriTimLomba>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<IMailService, MailService>();

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
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapRazorPages();

app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Dashboard",
    pattern: "Dashboard/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
