using System;
using System.Net.Http;
using VT.NET.Constants;
using VT.NET.Http;

namespace VT.NET.Endpoints
{
    /// <summary>
    /// Represents a client endpoint for interacting with the VirusTotal API.
    /// </summary>
    /// <remarks>
    /// This class extends the <see cref="RestClient"/> to provide a specific configuration
    /// for the VirusTotal API, setting the base address used for API requests.
    /// </remarks>
    public class VTEndpoint : RestClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VTEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">An <see cref="HttpClient"/> instance used for making HTTP requests.</param>
        /// <param name="apiKey">VirusTotal API key</param>
        public VTEndpoint(HttpClient httpClient, string apiKey) : base(httpClient)
        {
            SetVirusTotalAddress();
            AddDefaultRequestHeader(VTHeaderNames.ApiKey, apiKey);
        }

        /// <summary>
        /// Sets the base address for the VirusTotal API.
        /// </summary>
        /// <remarks>
        /// The base address is set to "https://www.virustotal.com/api/v3/". If the current 
        /// base address is null or does not match the expected VirusTotal API address, 
        /// it updates the base address accordingly.
        /// </remarks>
        private void SetVirusTotalAddress()
        {
            if (BaseAddress == null
                || BaseAddress.OriginalString != "https://www.virustotal.com/api/v3/"
                || BaseAddress.OriginalString != "https://www.virustotal.com/api/v3")
            {
                BaseAddress = new Uri("https://www.virustotal.com/api/v3/");
            }
        }
    }
}
