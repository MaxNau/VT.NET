using Microsoft.Extensions.Configuration;
using System;

namespace VT.NET.DependencyInjection.Extensions.Internal
{
    internal static class VTConfigurationLoader
    {
        internal static VTConfiguration GetConfiguration(IConfiguration configuration)
        {
            var vtConfiguration = configuration
                .GetSection(VTConfiguration.VTConfigurationSectionName)
                .Get<VTConfiguration>();

            if (vtConfiguration == null)
            {
                throw new InvalidOperationException("VTConfiguration section is missing or invalid.");
            }

            return vtConfiguration;
        }
    }
}
