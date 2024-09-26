using System;
using System.Collections.Generic;
using System.IO;
using VT.NET.Constants;

namespace VT.NET.Validators
{
    internal class VTFilesValidator : IVTFilesValidator
    {
        private readonly long _regularFileSizeLimit = 31 << FileSize.MB;
        private readonly long _largeFileSizeLimit = 649 << FileSize.MB;

        public FileValidationResult ValidateFile(string filePath)
        {
            var fileInfo = new FileInfo(filePath);

            if (!fileInfo.Exists)
            {
                throw new FileNotFoundException(filePath);
            }

            return ValidateSize(fileInfo.Length);
        }

        public FileValidationResult ValidateStream(Stream stream)
        {
            if (stream == null || stream.Length == 0)
            {
                throw new ArgumentException("Stream is null or empty");
            }

            return ValidateSize(stream.Length);
        }

        public bool ValidateHash(string hash)
        {
            return IsValidHashString(hash);
        }

        Dictionary<int, HashType> _hashes = new Dictionary<int, HashType>
        {
            { 32, HashType.Md5 },
            { 40, HashType.Sha1 },
            { 64, HashType.Sha256 }
        };

        private bool IsValidHash(string hash)
        {
            return _hashes.ContainsKey(hash.Length) && IsValidHashString(hash);
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

        private FileValidationResult ValidateSize(long length)
        {
            if (length <= _regularFileSizeLimit)
            {
                return FileValidationResult.SmallFile;
            }
            else if (length <= _largeFileSizeLimit)
            {
                return FileValidationResult.LargeFile;
            }
            else
            {
                throw new InvalidOperationException("Max file limit is 650MB");
            }
        }
    }

    internal enum FileValidationResult
    {
        SmallFile,
        LargeFile
    }

    internal enum HashType
    {
        Unknown,
        Sha1,
        Md5,
        Sha256
    }
}
