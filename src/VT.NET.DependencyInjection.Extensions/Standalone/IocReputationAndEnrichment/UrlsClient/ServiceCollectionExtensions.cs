using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VT.NET.DependencyInjection.Extensions.Internal;

namespace VT.NET.DependencyInjection.Extensions.Standalone.IocReputationAndEnrichment.UrlsClient
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddVTUrlsClient(this IServiceCollection services, string apiKey, string apiUrl = "https://www.virustotal.com/api/v3/",
            int pooledConnectionLifetimeInMinutes = 2)
        {
            ParametersValidator.ValidateParameters(apiKey, apiUrl);
            return VTClientRegistrationFactory.Register(services, apiKey, apiUrl, pooledConnectionLifetimeInMinutes, vtClients: VTClients.Urls);
        }

        public static IServiceCollection AddVTUrlsClient(this IServiceCollection services, IConfiguration configuration,
           int pooledConnectionLifetimeInMinutes = 2)
        {
            var vtConfiguration = VTConfigurationLoader.GetConfiguration(configuration);
            ParametersValidator.ValidateParameters(vtConfiguration.ApiKey, vtConfiguration.Url);
            return VTClientRegistrationFactory.Register(services, configuration: configuration, pooledConnectionLifetimeInMinutes: pooledConnectionLifetimeInMinutes, vtClients: VTClients.Urls);
        }
    }
}
