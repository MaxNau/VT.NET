using System.IO;
using System.Threading.Tasks;
using System;
using VT.NET.Internal;

namespace VT.NET.Utility
{
    public class FileHasher
    {
        private readonly IHashAlgorithmFactory _hashAlgorithmFactory;
        public FileHasher()
        {
            _hashAlgorithmFactory = new HashAlgorithmFactory();
        }

        internal FileHasher(IHashAlgorithmFactory hashAlgorithmFactory)
        {
            _hashAlgorithmFactory = hashAlgorithmFactory;
        }

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
