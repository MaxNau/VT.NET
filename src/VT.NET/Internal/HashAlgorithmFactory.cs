using System.Security.Cryptography;
using VT.NET.Utility;

namespace VT.NET.Internal
{
    internal class HashAlgorithmFactory : IHashAlgorithmFactory
    {
        HashAlgorithm IHashAlgorithmFactory.Create(HashAlgorithmEnum hashAlgorithm)
        {
            switch (hashAlgorithm)
            {
                case HashAlgorithmEnum.SHA256:
                    return SHA256.Create();
                case HashAlgorithmEnum.SHA1:
                    return SHA1.Create();
                case HashAlgorithmEnum.MD5:
                    return MD5.Create();
            }
            return default;
        }
    }
}
