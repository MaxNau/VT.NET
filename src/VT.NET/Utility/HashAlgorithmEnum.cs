namespace VT.NET.Utility
{
    /// <summary>
    /// Defines the available hash algorithms that can be used for computing hash values.
    /// </summary>
    /// <remarks>
    /// The <see cref="HashAlgorithmEnum"/> enumeration includes common hashing algorithms 
    /// that are supported for file hashing operations.
    /// </remarks>
    public enum HashAlgorithmEnum
    {
        /// <summary>
        /// Represents the SHA-256 hash algorithm, providing a 256-bit hash value.
        /// </summary>
        SHA256,

        /// <summary>
        /// Represents the SHA-1 hash algorithm, providing a 160-bit hash value.
        /// </summary>
        SHA1,

        /// <summary>
        /// Represents the MD5 hash algorithm, providing a 128-bit hash value.
        /// </summary>
        MD5
    }
}
