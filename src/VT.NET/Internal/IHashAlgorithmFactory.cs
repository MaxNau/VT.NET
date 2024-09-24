using System.Security.Cryptography;
using VT.NET.Utility;
namespace VT.NET.Internal
{
    internal interface IHashAlgorithmFactory
    {
        HashAlgorithm Create(HashAlgorithmEnum hashAlgorithm);
    }
}
