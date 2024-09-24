using System;
using System.IO;
using VT.NET.Constants;

namespace VT.NET.Validators
{
    internal class FileSizeValidator : IValidator<string>
    {
        public ValidationResult Validate(string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            if (fileInfo.Length == SupportedFileSizes.LargeFileSizeLimit)
            {
                return new ValidationResult(new InvalidOperationException("Max file size limit is 650MB"));
            }

            return new ValidationResult();
        }
    }
}
