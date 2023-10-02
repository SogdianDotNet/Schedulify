using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Schedulify.Application.Interfaces;
using Schedulify.Infrastructure.Repositories;

namespace Schedulify.Infrastructure;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionInfrastructure
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.TryAddScoped<ICompanyRepository, CompanyRepository>();
        services.TryAddScoped<ICompanySettingsRepository, CompanySettingsRepository>();
        services.TryAddScoped<IUserRepository, UserRepository>();
    }
}