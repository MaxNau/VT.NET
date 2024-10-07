using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Relationship.SslCertificate
{
    /// <summary>
    /// Represents an SSL certificate object.
    /// </summary>
    public class SslCertificateObject : VTObject
    {
        internal SslCertificateObject() { }

        [JsonConstructor]
        internal SslCertificateObject(string id, string type, Links links, SslCertificateObjectAttributes attributes)
            : base(id, type, links)
        {
            Attributes = attributes;
        }

        /// <summary>
        /// Attributes of the certificate.
        /// </summary>
        public SslCertificateObjectAttributes Attributes { get; }
    }
}
