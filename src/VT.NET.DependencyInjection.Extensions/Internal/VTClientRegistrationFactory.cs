using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using VT.NET.Constants;
using VT.NET.Endpoints;
using VT.NET.Utility;
using VT.NET.Internal;
using VT.NET.Http;

namespace VT.NET.DependencyInjection.Extensions.Internal
{
    internal static class VTClientRegistrationFactory
    {
    #if NET5_0_OR_GREATER || NETCOREAPP2_1_OR_GREATER
        private static readonly int DefaultPooledConnectionLifetimeInMinutes = 2;
    #endif

        internal static IServiceCollection Register(IServiceCollection services, string apiKey = null, string apiUrl = "https://www.virustotal.com/api/v3/",
            int pooledConnectionLifetimeInMinutes = 2, IConfiguration configuration = null, VTClients? vtClients = null)
        {
            if (vtClients == null)
            {
                return services;
            }

            if (configuration != null)
            {
                var vtConfiguration = configuration
                    .GetSection(VTConfiguration.VTConfigurationSectionName)
                    .Get<VTConfiguration>();

                if (vtConfiguration != null)
                {
                    apiKey = vtConfiguration.ApiKey;
                    apiUrl = vtConfiguration.Url;
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
            
                
            switch (vtClients)
            {
                case VTClients.Files:
                    services.AddSingleton<IVTFiles, VTFiles>(factory =>
                    {
                         return new VTFiles(client, apiKey);
                    });
                    break;
                case VTClients.Urls:
                    services.AddSingleton<IVTUrls, VTUrls>(factory =>
                    {
                        return new VTUrls(client, apiKey);
                    });
                    break;
                case VTClients.IPs:
                    services.AddSingleton<IVTIPs, VTIPs>(factory =>
                    {
                        return new VTIPs(client, apiKey);
                    });
                    break;
                case VTClients.Domains:
                    services.AddSingleton<IVTDomains, VTDomains>(factory =>
                    {
                        return new VTDomains(client, apiKey);
                    });
                    break;
                case VTClients.AllInOnePublicClient:
                    services.AddSingleton<IVTPublicClient, VTClient>(factory =>
                    {
                        return new VTClient(client, apiKey);
                    });
                    break;
                default:
                    break;
             }
#else

            switch (vtClients)
            {
                case VTClients.Files:
                    services.AddHttpClient<IVTFiles, VTFiles>()
                        .ConfigureHttpClient(client =>
                        {
                            client.DefaultRequestHeaders.Add(VTHeaderNames.ApiKey, apiKey);
                            client.BaseAddress = new Uri(apiUrl);
                        });
                    break;
                case VTClients.Urls:
                    services.AddHttpClient<IVTUrls, VTUrls>()
                        .ConfigureHttpClient(client =>
                        {
                            client.DefaultRequestHeaders.Add(VTHeaderNames.ApiKey, apiKey);
                            client.BaseAddress = new Uri(apiUrl);
                        });
                    break;
                case VTClients.IPs:
                    services.AddHttpClient<IVTIPs, VTIPs>()
                    .ConfigureHttpClient(client =>
                    {
                        client.DefaultRequestHeaders.Add(VTHeaderNames.ApiKey, apiKey);
                        client.BaseAddress = new Uri(apiUrl);
                    });
                    break;
                case VTClients.Domains:
                    services.AddHttpClient<IVTDomains, VTDomains>()
                    .ConfigureHttpClient(client =>
                    {
                        client.DefaultRequestHeaders.Add(VTHeaderNames.ApiKey, apiKey);
                        client.BaseAddress = new Uri(apiUrl);
                    });
                    break;
                case VTClients.AllInOnePublicClient:
                    services.AddHttpClient<IVTPublicClient, VTClient>()
                    .ConfigureHttpClient(client =>
                    {
                        client.DefaultRequestHeaders.Add(VTHeaderNames.ApiKey, apiKey);
                        client.BaseAddress = new Uri(apiUrl);
                    });
                    break;
                default:
                    break;
            }
#endif

            return services;
        }
    }
}
