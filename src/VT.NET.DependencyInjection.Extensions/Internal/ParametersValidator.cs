using System;

namespace VT.NET.DependencyInjection.Extensions.Internal
{
    internal static class ParametersValidator
    {
        internal static void ValidateParameters(string apiKey, string apiUrl)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("API key cannot be null or empty.", nameof(apiKey));
            }

            if (string.IsNullOrEmpty(apiUrl))
            {
                throw new ArgumentException("API URL cannot be null or empty.", nameof(apiUrl));
            }
        }
    }
}
