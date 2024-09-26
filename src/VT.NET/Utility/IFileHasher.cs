namespace VT.NET.Utility
{
    /// <summary>
    /// Interface for hashing files using various algorithms.
    /// </summary>
    public interface IFileHasher
    {
        /// <summary>
        /// Computes the hash of the specified file.
        /// </summary>
        /// <param name="filePath">The path to the file to be hashed.</param>
        /// <param name="hashAlgorithmEnum">The hashing algorithm to use.</param>
        /// <returns>The computed hash as a string.</returns>
        string GetHash(string filePath, HashAlgorithmEnum hashAlgorithmEnum);
    }
}
