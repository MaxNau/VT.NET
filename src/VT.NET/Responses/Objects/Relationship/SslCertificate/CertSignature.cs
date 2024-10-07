using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Relationship.SslCertificate
{
    /// <summary>
    /// Contains the signature information of the certificate.
    /// </summary>
    public class CertSignature
    {
        internal CertSignature() { }

        [JsonConstructor]
        internal CertSignature(string signature, string signatureAlgorithm)
        {
            Signature = signature;
            SignatureAlgorithm = signatureAlgorithm;
        }

        /// <summary>
        /// Gets or sets the signature hex dump.
        /// </summary>
        public string Signature { get; }

        /// <summary>
        /// Gets or sets the signature algorithm used.
        /// </summary>
        public string SignatureAlgorithm { get; }
    }
}
