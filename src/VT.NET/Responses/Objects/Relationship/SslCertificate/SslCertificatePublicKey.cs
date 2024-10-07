using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Relationship.SslCertificate
{
    /// <summary>
    /// Contains public key information of the certificate.
    /// </summary>
    public class SslCertificatePublicKey
    {
        internal SslCertificatePublicKey() { }

        [JsonConstructor]
        internal SslCertificatePublicKey(string algorithm, RsaPublicKey rsa, DsaPublicKey dsa, EcPublicKey ec)
        {
            Algorithm = algorithm;
            Rsa = rsa;
            Dsa = dsa;
            Ec = ec;
        }

        /// <summary>
        /// any of "RSA", "DSA" or "EC". Indicates the algorithm used to generate the certificate.
        /// </summary>
        public string Algorithm { get; }

        /// <summary>
        /// RSA public key information.
        /// </summary>
        public RsaPublicKey Rsa { get; }

        /// <summary>
        /// DSA public key information.
        /// </summary>
        public DsaPublicKey Dsa { get; }

        /// <summary>
        /// EC public key information.
        /// </summary>
        public EcPublicKey Ec { get; }
    }

    /// <summary>
    /// Contains RSA public key information.
    /// </summary>
    public class RsaPublicKey
    {
        internal RsaPublicKey() { }

        [JsonConstructor]
        internal RsaPublicKey(int keySize, string modulus, string exponent)
        {
            KeySize = keySize;
            Modulus = modulus;
            Exponent = exponent;
        }

        /// <summary>
        /// Key size.
        /// </summary>
        public int KeySize { get; }

        /// <summary>
        /// Key modulus hexdump.
        /// </summary>
        public string Modulus { get; }

        /// <summary>
        /// Key exponent hexdump.
        /// </summary>
        public string Exponent { get; }
    }

    /// <summary>
    /// Contains DSA public key information.
    /// </summary>
    public class DsaPublicKey
    {
        internal DsaPublicKey() { }

        [JsonConstructor]
        internal DsaPublicKey(string p, string q, string g, string pub)
        {
            P = p;
            Q = q;
            G = g;
            Pub = pub;
        }

        /// <summary>
        /// P component hexdump.
        /// </summary>
        public string P { get; }

        /// <summary>
        /// Q component hexdump.
        /// </summary>
        public string Q { get; }

        /// <summary>
        /// G component hexdump.
        /// </summary>
        public string G { get; }

        /// <summary>
        /// Pub component hexdump.
        /// </summary>
        public string Pub { get; }
    }

    /// <summary>
    /// Contains EC public key information.
    /// </summary>
    public class EcPublicKey
    {
        internal EcPublicKey() { }

        [JsonConstructor]
        internal EcPublicKey(string oid, string pub)
        {
            Oid = oid;
            Pub = pub;
        }

        /// <summary>
        /// Curve name.
        /// </summary>
        public string Oid { get; }

        /// <summary>
        /// Public key hexdump.
        /// </summary>
        public string Pub { get; }
    }
}
