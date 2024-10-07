using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Relationship.SslCertificate
{
    /// <summary>
    /// Contains the attributes of the SSL certificate.
    /// </summary>
    public class SslCertificateObjectAttributes : VTObjectAttributes
    {
        internal SslCertificateObjectAttributes() { }

        [JsonConstructor]
        internal SslCertificateObjectAttributes(CertSignature certSignature, SslCertificateExtensions extensions,
            long firstSeenDate, Issuer issuer, SslCertificatePublicKey publicKey, string serialNumber,
            string signatureAlgorithm, int size, Subject subject, string thumbprint, string thumbprintSha256,
            Validity validity, string version)
        {
            CertSignature = certSignature;
            Extensions = extensions;
            FirstSeenDate = firstSeenDate;
            Issuer = issuer;
            PublicKey = publicKey;
            SerialNumber = serialNumber;
            SignatureAlgorithm = signatureAlgorithm;
            Size = size;
            Subject = subject;
            Thumbprint = thumbprint;
            ThumbprintSha256 = thumbprintSha256;
            Validity = validity;
            Version = version;
        }

        /// <summary>
        /// Gets or sets the certificate's signature information.
        /// </summary>
        public CertSignature CertSignature { get; }

        /// <summary>
        /// Gets or sets the extensions of the certificate.
        /// </summary>
        public SslCertificateExtensions Extensions { get; }

        /// <summary>
        /// Gets or sets the timestamp of when the certificate was first seen.
        /// </summary>
        public long FirstSeenDate { get; }

        /// <summary>
        /// Gets or sets the issuer information.
        /// </summary>
        public Issuer Issuer { get; }

        /// <summary>
        /// Gets or sets the public key information.
        /// </summary>
        public SslCertificatePublicKey PublicKey { get; }

        /// <summary>
        /// Gets or sets the serial number of the certificate.
        /// </summary>
        public string SerialNumber { get; }

        /// <summary>
        /// Gets or sets the signature algorithm used.
        /// </summary>
        public string SignatureAlgorithm { get; }

        /// <summary>
        /// Gets or sets the size of the certificate.
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// Gets or sets the subject information of the certificate.
        /// </summary>
        public Subject Subject { get; }

        /// <summary>
        /// Gets or sets the SHA1 hash of the certificate.
        /// </summary>
        public string Thumbprint { get; }

        /// <summary>
        /// Gets or sets the SHA256 hash of the certificate.
        /// </summary>
        public string ThumbprintSha256 { get; }

        /// <summary>
        /// Gets or sets the validity period of the certificate.
        /// </summary>
        public Validity Validity { get; }

        /// <summary>
        /// Gets or sets the version of the certificate.
        /// </summary>
        public string Version { get; }
    }
}
