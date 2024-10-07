using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Relationship.SslCertificate
{
    /// <summary>
    /// Contains the authority key identifier information.
    /// </summary>
    public class AuthorityKeyIdentifier
    {
        internal AuthorityKeyIdentifier() { }

        [JsonConstructor]
        internal AuthorityKeyIdentifier(string keyid, string serialNumber)
        {
            Keyid = keyid;
            SerialNumber = serialNumber;
        }

        /// <summary>
        /// Gets or sets the key identifier hex dump.
        /// </summary>
        public string Keyid { get; }

        /// <summary>
        /// Gets or sets the serial number hex dump.
        /// </summary>
        public string SerialNumber { get; }
    }
}
