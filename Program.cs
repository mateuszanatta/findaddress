using Microsoft.EntityFrameworkCore;
using AddressService.Data;
using AddressService.HttpClients.Interfaces;
using AddressService.HttpClients;
using AddressService.Services.Interfaces;
using AddressService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InMem"));
builder.Services.AddTransient<IAddressRepo, AddressRepo>();
builder.Services.AddScoped<IHttpClients, DefaultHttpClient>();
builder.Services.AddScoped<IPostCodesIOService, PostCodesIOService>();
builder.Services.AddTransient<IAddressesService, AddressesService>();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
