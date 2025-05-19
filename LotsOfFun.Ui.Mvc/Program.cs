
using LotsOfFun.Repository;
using LotsOfFun.Services;
using LotsOfFun.Services.Helper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString(nameof(LotsOfFunDbContext));
builder.Services.AddDbContext<LotsOfFunDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<PersonService>();
builder.Services.AddScoped<ActivityService>();



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

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
