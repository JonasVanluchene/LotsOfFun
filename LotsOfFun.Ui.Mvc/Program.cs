
using LotsOfFun.Model;
using LotsOfFun.Repository;
using LotsOfFun.Services;
using LotsOfFun.Services.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDefaultIdentity<Person>(options =>
    {
        //options.SignIn.RequireConfirmedAccount = true;

    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LotsOfFunDbContext>()
    ;



builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/Identity/SignIn";
    options.AccessDeniedPath = "/Identity/SignIn";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    options.SlidingExpiration = true;
});


var connectionString = builder.Configuration.GetConnectionString(nameof(LotsOfFunDbContext));
builder.Services.AddDbContext<LotsOfFunDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<PersonService>();
builder.Services.AddScoped<ActivityService>();
builder.Services.AddScoped<LocationService>();



builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<LotsOfFun.Ui.Mvc.Mapping.MvcMappingProfile>();
    cfg.AddProfile<LotsOfFun.Services.Mapping.MappingProfile>();
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{

    using (var scope = app.Services.CreateScope())
    {
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        string[] roleNames = { "Admin", "User" }; // Add roles as needed

        foreach (var roleName in roleNames)
        {
            var roleExists = await roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
    }
}

    app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
