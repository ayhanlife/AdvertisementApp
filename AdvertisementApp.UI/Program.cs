
using AdvertisementApp.Bussniess.DependencyResolvers.Microsoft;
using AdvertisementApp.UI.Models;
using AdvertisementApp.UI.ValidationRules;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<IValidator<UserCreateModel>, UserCreateModelValidator>();
builder.Services.AddControllersWithViews();
builder.Services.AddDependencies(builder.Configuration);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.Cookie.Name = "LifeCookie";
        opt.Cookie.HttpOnly = true;//client scriptlerden korur
        opt.Cookie.SameSite = SameSiteMode.Strict;//cookie paylaþýma kapat
        opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        opt.ExpireTimeSpan = TimeSpan.FromDays(20);
        opt.LoginPath = new PathString("/Account/SignIn");
        opt.LogoutPath = new PathString("/Account/LogOut");
        opt.AccessDeniedPath = new PathString("/Account/AccessDenied");
    });






var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
//app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapDefaultControllerRoute();
app.Run();
