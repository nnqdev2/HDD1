using HDD.Infrastructure.Services;
using HDD.Web.Interfaces;
using HDD.Web.Services;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace HDD.Web.Configuration;

public static class ConfigureWebServices
{
    public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IHDDRepository, HDDRepository>();
        services.AddTransient<IEmailService, EmailService>();
        //services.AddTransient<IFileUploadService, FileUploadService>();
        services.AddTransient<IVinOwnershipService, VinOwnershipService>();
        services.AddTransient<IVinService, VinService>();
        services.AddTransient<IEmailSender, EmailSender>();

        return services;
    }
}