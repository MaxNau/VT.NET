using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using VT.NET.Constants;
using VT.NET.Endpoints;
using VT.NET.Utility;
using VT.NET.Internal;

namespace VT.NET.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        #if NET5_0_OR_GREATER || NETCOREAPP2_1_OR_GREATER
        private static readonly int DefaultPooledConnectionLifetimeInMinutes = 2;
        #endif

        public static IServiceCollection AddVTFilesClient(this IServiceCollection services, string apiKey, string apiUrl = "https://www.virustotal.com/api/v3/",
            int pooledConnectionLifetimeInMinutes = 2)
        {
            return RegisterVTFilesClient(services, apiKey, apiUrl, pooledConnectionLifetimeInMinutes);
        }

        public static IServiceCollection AddVTFilesClient(this IServiceCollection services, IConfiguration configuration,
           int pooledConnectionLifetimeInMinutes = 2)
        {
            var vtConfiguration = configuration.GetSection(VTConfiguration.VTConfigurationSectionName)
                .Get<VTConfiguration>();

            return RegisterVTFilesClient(services, configuration: configuration, pooledConnectionLifetimeInMinutes: pooledConnectionLifetimeInMinutes);
        }

        private static IServiceCollection RegisterVTFilesClient(IServiceCollection services, string apiKey = null, string apiUrl = "https://www.virustotal.com/api/v3/",
            int pooledConnectionLifetimeInMinutes = 2, IConfiguration configuration = null)
        {
            if (configuration != null)
            {
                var materialsProjectConfig = configuration
                    .GetSection(VTConfiguration.VTConfigurationSectionName)
                    .Get<VTConfiguration>();

                if (materialsProjectConfig != null)
                {
                    apiKey = materialsProjectConfig.ApiKey;
                    apiUrl = materialsProjectConfig.Url;
                }
            }

            services.AddSingleton<IHashAlgorithmFactory, HashAlgorithmFactory>();
            services.AddSingleton<IFileHasher, FileHasher>();
            services.AddSingleton<IAsyncFileHasher, FileHasher>();

#if NET5_0_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            var client = new HttpClient(
                new SocketsHttpHandler
                    {
                        PooledConnectionLifetime = TimeSpan.FromMinutes(pooledConnectionLifetimeInMinutes <= 0 ? DefaultPooledConnectionLifetimeInMinutes : pooledConnectionLifetimeInMinutes)
                    }, false)
                {
                    BaseAddress = new Uri(apiUrl)
                };
            
            services.AddSingleton<IVTFiles, VTFiles>(factory =>
            {
                return new VTFiles(client, apiKey);
            });
#else
            services.AddHttpClient<IVTFiles, VTFiles>()
                .ConfigureHttpClient(client =>
                {
                    client.DefaultRequestHeaders.Add(VTHeaderNames.ApiKey, apiKey);
                    client.BaseAddress = new Uri(apiUrl);
                });
#endif

            return services;
        }
    }
}
