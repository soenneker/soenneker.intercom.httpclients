using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Intercom.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Intercom.HttpClients.Registrars;

/// <summary>
/// Registers the OpenAPI HttpClient wrapper for dependency injection.
/// </summary>
public static class IntercomOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="IntercomOpenApiHttpClient"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddIntercomOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IIntercomOpenApiHttpClient, IntercomOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IntercomOpenApiHttpClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddIntercomOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IIntercomOpenApiHttpClient, IntercomOpenApiHttpClient>();

        return services;
    }
}
