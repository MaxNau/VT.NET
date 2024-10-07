using System.Text;
using System;

namespace VT.NET.Utility
{
    /// <summary>
    /// Responsible for generating URL identifiers for VirusTotal using Base64 encoding.
    /// </summary>
    public class VTUrlIdentifierGenerator : IVTUrlIdentifierGenerator, IVTUrlIdentifierDecoder
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
        public string EncodeUrlToBase64(string uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri), "The URI cannot be null.");
            }

            if (Uri.IsWellFormedUriString(!uri.StartsWith("http://") || !uri.StartsWith("https://") 
                ? "http://" + uri : uri, UriKind.Absolute))
            {
                throw new FormatException("Invalid URI format");
            }

            byte[] urlBytes = Encoding.UTF8.GetBytes(uri.ToString());
            string base64String = Convert.ToBase64String(urlBytes);
            return base64String.TrimEnd('=');
        }

        Uri IVTUrlIdentifierDecoder.DecodeUrlFromBase64(string encodedUri)
        {
            if (string.IsNullOrEmpty(encodedUri))
                return null;

            if (encodedUri.Length % 4 != 0)
                return null;

            foreach (char c in encodedUri)
            {
                if (!char.IsLetterOrDigit(c) && c != '+' && c != '/' && c != '=')
                    return null;
            }

            if (encodedUri.EndsWith("=="))
                return null;
            if (encodedUri.EndsWith("="))
                return null;

            string url = null;
            int padding = 4 - (encodedUri.Length % 4);
            if (padding != 4)
            {
                encodedUri += new string('=', padding);
            }

            try
            {
                url = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUri));
            }
            catch (FormatException)
            {
                return null;
            }

            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                return new Uri(url);
            }

            return null;
        }
    }
}
