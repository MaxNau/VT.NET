using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Relationship.SslCertificate
{
    /// <summary>
    /// Contains subject information of the certificate.
    /// </summary>
    public class Subject
    {
        internal Subject() { }

        [JsonConstructor]
        internal Subject(string c, string cN, string l, string o, string oU, string sT)
        {
            C = c;
            CN = cN;
            L = l;
            O = o;
            OU = oU;
            ST = sT;
        }

        /// <summary>
        /// CountryName
        /// </summary>
        public string C { get; }

        /// <summary>
        /// CommonName
        /// </summary>
        public string CN { get; }

        /// <summary>
        /// Locality
        /// </summary>
        public string L { get; }

        /// <summary>
        /// Organization
        /// </summary>
        public string O { get; }

        /// <summary>
        /// OrganizationalUnit
        /// </summary>
        public string OU { get; }

        /// <summary>
        /// StateOrProvinceName
        /// </summary>
        public string ST { get; }
    }
}
