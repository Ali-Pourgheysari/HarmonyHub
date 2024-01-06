using HarmonyHub.Data;
using HarmonyHub.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using HarmonyHub.Services.Interfaces;
using HarmonyHub.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HarmonyHubDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("HarmonyHubConn"));
    }
    );

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<HarmonyHubDbContext>();

builder.Services.AddTransient<ISongService, SongService>();

var app = builder.Build();
app.MapRazorPages();

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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("Areas", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");
});



app.Run();
