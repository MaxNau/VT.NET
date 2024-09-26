using System.IO;
using System.Threading.Tasks;
using System;
using VT.NET.Internal;

namespace VT.NET.Utility
{
    /// <summary>
    /// Provides methods for computing hash values of files using different hashing algorithms.
    /// </summary>
    /// <remarks>
    /// The <see cref="FileHasher"/> class utilizes a factory to create instances of hash algorithms 
    /// and offers both asynchronous and synchronous methods for generating hash values 
    /// based on the specified algorithm.
    /// </remarks>
    public class FileHasher
    {
        private readonly IHashAlgorithmFactory _hashAlgorithmFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileHasher"/> class 
        /// using a default hash algorithm factory.
        /// </summary>
        public FileHasher()
        {
            _hashAlgorithmFactory = new HashAlgorithmFactory();
        }

        internal FileHasher(IHashAlgorithmFactory hashAlgorithmFactory)
        {
            _hashAlgorithmFactory = hashAlgorithmFactory;
        }

        /// <summary>
        /// Computes the hash of a file asynchronously.
        /// </summary>
        /// <param name="filePath">The path to the file to be hashed.</param>
        /// <param name="hashAlgorithmEnum">The hashing algorithm to be used.</param>
        /// <returns>A task that represents the asynchronous operation, with a string result containing the hash value.</returns>
        public async Task<string> GetHashAsync(string filePath, HashAlgorithmEnum hashAlgorithmEnum)
        {
            using (var hashAlgorithm = _hashAlgorithmFactory.Create(hashAlgorithmEnum))
            {
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 8192, true))
                {
                    byte[] buffer = new byte[8192];
                    int bytesRead;

                    while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false)) > 0)
                    {
                        hashAlgorithm.TransformBlock(buffer, 0, bytesRead, null, 0);
                    }

                    hashAlgorithm.TransformFinalBlock(buffer, 0, 0);
                }

                return BitConverter.ToString(hashAlgorithm.Hash).Replace("-", "").ToLowerInvariant();
            }
        }

        /// <summary>
        /// Computes the hash of a file synchronously.
        /// </summary>
        /// <param name="filePath">The path to the file to be hashed.</param>
        /// <param name="hashAlgorithmEnum">The hashing algorithm to be used.</param>
        /// <returns>A string containing the hash value of the file.</returns>
        public string GetHash(string filePath, HashAlgorithmEnum hashAlgorithmEnum)
        {
            using (var hashAlgorithm = _hashAlgorithmFactory.Create(hashAlgorithmEnum))
            {
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 8192))
                {
                    byte[] buffer = new byte[8192];
                    int bytesRead;

                    while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        hashAlgorithm.TransformBlock(buffer, 0, bytesRead, null, 0);
                    }

                    hashAlgorithm.TransformFinalBlock(buffer, 0, 0);
                }

                return BitConverter.ToString(hashAlgorithm.Hash).Replace("-", "").ToLowerInvariant();
            }
        }
    }
}
