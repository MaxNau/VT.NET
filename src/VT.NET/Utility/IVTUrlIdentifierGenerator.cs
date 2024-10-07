using System;

namespace VT.NET.Utility
{
    /// <summary>
    /// Defines a contract for generating URL identifiers for VirusTotal.
    /// </summary>
    public interface IVTUrlIdentifierGenerator
    {
        /// <summary>
        /// Encodes a given URI into an unpadded Base64 string.
        /// This method takes a URI, converts it to a UTF-8 byte array,
        /// and encodes it using Base64 encoding without padding characters.
        /// </summary>
        /// <param name="uri">The URI to be encoded. Must not be null.</param>
        /// <returns>
        /// An unpadded Base64 string representation of the specified URI.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="uri"/> is null.</exception>
        string EncodeUrlToBase64(Uri uri);

        /// <summary>
        /// Encodes a given URI into an unpadded Base64 string.
        /// This method converts the URI to a UTF-8 byte array, encodes it to Base64,
        /// and removes any padding characters ('=') as per the unpadded Base64 specification.
        /// </summary>
        /// <param name="uri">The URI to be encoded.</param>
        /// <returns>
        /// An unpadded Base64 string representation of the URI.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="uri"/> is null.</exception>
        /// <exception cref="FormatException">Thrown when the <paramref name="uri"/> is not well formed uri.</exception>
        string EncodeUrlToBase64(string uri);
    }
}
