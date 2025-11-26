using KetabSara.CoreLayer.Config;
using KetabSara.DataLayer.Context;
using KetabSara.DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("KetabSaraDB")));

builder.Services.AddApplicationService();

builder.Services.AddIdentity<User, Role>(option =>
    {
        option.Password.RequireDigit = false;
        option.Password.RequireLowercase = false;
        option.Password.RequireNonAlphanumeric = false;
        option.Password.RequireUppercase = false;
        option.Password.RequiredLength = 8;
        option.Password.RequiredUniqueChars = 0;


        option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        option.Lockout.MaxFailedAccessAttempts = 5;
        option.Lockout.AllowedForNewUsers = true;
        option.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<AppDbContext>()
    .AddSignInManager<SignInManager<User>>()
    .AddDefaultTokenProviders();


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
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
