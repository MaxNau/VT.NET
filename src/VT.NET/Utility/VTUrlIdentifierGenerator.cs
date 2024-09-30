using System.Text;
using System;

namespace VT.NET.Utility
{
    /// <summary>
    /// Responsible for generating URL identifiers for VirusTotal using Base64 encoding.
    /// </summary>
    public class VTUrlIdentifierGenerator : IVTUrlIdentifierGenerator
    {
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
        public string EncodeUrlToBase64(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri), "The URI cannot be null.");
            }

            byte[] urlBytes = Encoding.UTF8.GetBytes(uri.ToString());
            string base64String = Convert.ToBase64String(urlBytes);
            return base64String.TrimEnd('=');
        }
    }
}
