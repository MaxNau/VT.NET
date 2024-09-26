using System.Threading.Tasks;

namespace VT.NET.Utility
{
    /// <summary>
    /// Interface for asynchronously hashing files using various algorithms.
    /// </summary>
    public interface IAsyncFileHasher
    {
        /// <summary>
        /// Asynchronously computes the hash of the specified file.
        /// </summary>
        /// <param name="filePath">The path to the file to be hashed.</param>
        /// <param name="hashAlgorithmEnum">The hashing algorithm to use.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the computed hash as a string.</returns>
        Task<string> GetHashAsync(string filePath, HashAlgorithmEnum hashAlgorithmEnum);
    }
}
