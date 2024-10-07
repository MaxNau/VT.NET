using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Relationship.SslCertificate
{
    /// <summary>
    /// Contains validity information of the certificate.
    /// </summary>
    public class Validity
    {
        internal Validity() { }

        [JsonConstructor]
        internal Validity(string notAfter, string notBefore)
        {
            NotAfter = notAfter;
            NotBefore = notBefore;
        }

        /// <summary>
        /// Gets or sets the expiry date.
        /// </summary>
        public string NotAfter { get; }

        /// <summary>
        /// Gets or sets the issue date.
        /// </summary>
        public string NotBefore { get; }
    }
}
