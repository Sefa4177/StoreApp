using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Abstract;
using StoreApp.Data.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var app = builder.Build();

builder.Services.AddDbContext<StoreDbContext>(options => {
    options.UseSqlite(builder.Configuration["ConnectionStrings:StoreDbConnection"]);
});

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
