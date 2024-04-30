using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var Configuration = builder.Configuration;
builder.Services.AddDbContext<StoreDbContext>(opts =>
{
    opts.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();
app.MapDefaultControllerRoute();

SeedData.EnsurePopulated(app);

app.Run();
