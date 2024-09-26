using System;
using System.Collections.Generic;

namespace VT.NET.Validators
{
    internal class FileHashValidator : IValidator<string>
    {
        private readonly Dictionary<int, HashType> _knownHashSizes = new Dictionary<int, HashType>
        {
            { 32, HashType.Md5 },
            { 40, HashType.Sha1 },
            { 64, HashType.Sha256 }
        };

        public ValidationResult Validate(string hash)
        {
            if (!IsValidHash(hash))
            {
                return new ValidationResult(new InvalidOperationException("Unknown hash type. Expected Md5, Sha1 or Sha256 hash."));
            }

            return new ValidationResult();
        }

        private bool IsValidHash(string hash)
        {
            return _knownHashSizes.ContainsKey(hash.Length) && IsValidHashString(hash);
        }

        bool IsValidHashString(string hashString)
        {
            foreach (char c in hashString)
            {
                if (!IsHexadecimal(c))
                {
                    return false;
                }
            }

            return true;
        }

        bool IsHexadecimal(char c)
        {
            return (c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F');
        }
    }
}
