using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Relationship.SslCertificate
{
    /// <summary>
    /// Contains the extensions of the SSL certificate.
    /// </summary>
    public class SslCertificateExtensions
    {
        internal SslCertificateExtensions() { }

        [JsonConstructor]
        internal SslCertificateExtensions(bool cA, AuthorityKeyIdentifier authorityKeyIdentifier,
            Dictionary<string, string> caInformationAccess, List<string> certificatePolicies,
            string certTemplateNameDc, List<string> crlDistributionPoints, List<string> extendedKeyUsage,
            List<string> keyUsage, string netscapeCertComment, bool netscapeCertificate,
            bool oldAuthorityKeyIdentifier, bool peLogotype, List<string> subjectAlternativeName,
            string subjectKeyIdentifier, Dictionary<string, string> additionalExtensions)
        {
            CA = cA;
            AuthorityKeyIdentifier = authorityKeyIdentifier;
            CaInformationAccess = caInformationAccess;
            CertificatePolicies = certificatePolicies;
            CertTemplateNameDc = certTemplateNameDc;
            CrlDistributionPoints = crlDistributionPoints;
            ExtendedKeyUsage = extendedKeyUsage;
            KeyUsage = keyUsage;
            NetscapeCertComment = netscapeCertComment;
            NetscapeCertificate = netscapeCertificate;
            OldAuthorityKeyIdentifier = oldAuthorityKeyIdentifier;
            PeLogotype = peLogotype;
            SubjectAlternativeName = subjectAlternativeName;
            SubjectKeyIdentifier = subjectKeyIdentifier;
            AdditionalExtensions = additionalExtensions;
        }

        /// <summary>
        /// Whether the subject acts as a CA or not.
        /// </summary>
        public bool CA { get; }

        /// <summary>
        /// Gets or sets the authority key identifier details.
        /// </summary>
        public AuthorityKeyIdentifier AuthorityKeyIdentifier { get; }

        /// <summary>
        /// Gets or sets the authority information access URLs.
        /// </summary>
        public Dictionary<string, string> CaInformationAccess { get; }

        /// <summary>
        /// Gets or sets the certificate policies.
        /// </summary>
        public List<string> CertificatePolicies { get; }

        /// <summary>
        /// Gets or sets the certificate's template name.
        /// </summary>
        public string CertTemplateNameDc { get; }

        /// <summary>
        /// Gets or sets the CRL distribution points.
        /// </summary>
        public List<string> CrlDistributionPoints { get; }

        /// <summary>
        /// Gets or sets the extended key usage.
        /// </summary>
        public List<string> ExtendedKeyUsage { get; }

        /// <summary>
        /// Gets or sets the key usage.
        /// </summary>
        public List<string> KeyUsage { get; }

        /// <summary>
        /// Gets or sets comments in the Netscape format.
        /// </summary>
        public string NetscapeCertComment { get; }

        /// <summary>
        /// Indicates if the certificate is a Netscape certificate.
        /// </summary>
        public bool NetscapeCertificate { get; }

        /// <summary>
        /// Indicates if the certificate has an old authority key identifier.
        /// </summary>
        public bool OldAuthorityKeyIdentifier { get; }

        /// <summary>
        /// Indicates if the certificate includes a logotype.
        /// </summary>
        public bool PeLogotype { get; }

        /// <summary>
        /// Gets or sets the subject alternative names.
        /// </summary>
        public List<string> SubjectAlternativeName { get; }

        /// <summary>
        /// Gets or sets the subject key identifier.
        /// </summary>
        public string SubjectKeyIdentifier { get; }

        /// <summary>
        /// Gets or sets additional extensions.
        /// </summary>
        public Dictionary<string, string> AdditionalExtensions { get; }
    }
}
