using BethanysPieShopHRM.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddDbContext<BethanysPieShopHRMDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("BethanysPieShopHRM")));

var app = builder.Build();

await EnsureDbCreated(app.Services, app.Logger);

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.MapDefaultControllerRoute();

app.Run();

async Task EnsureDbCreated(IServiceProvider services, ILogger logger)
{
    using var db = services.CreateScope()
        .ServiceProvider.GetRequiredService<BethanysPieShopHRMDbContext>();
    await db.Database.MigrateAsync();
}
