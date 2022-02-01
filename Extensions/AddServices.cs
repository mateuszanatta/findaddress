using AddressService.Data;
using AddressService.HttpClients;
using AddressService.HttpClients.Interfaces;
using AddressService.Services;
using AddressService.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AddressService.Extensions;

public static class AddServices
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InMem"));
        services.AddTransient<IAddressRepo, AddressRepo>();
        services.AddScoped<IHttpClients, DefaultHttpClient>();
        services.AddScoped<IPostCodesIOService, PostCodesIOService>();
        services.AddTransient<IAddressesService, AddressesService>();
        services.AddHttpClient();
    }
}