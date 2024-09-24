using System;
using System.IO;

namespace VT.NET.Validators
{
    internal class FilePathValidator : IValidator<string>
    {
        public ValidationResult Validate(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return new ValidationResult(new ArgumentNullException(nameof(filePath)));
            }

            var fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists)
            {
                return new ValidationResult(new FileNotFoundException($"File {filePath} not found", filePath));
            }

            return new ValidationResult();
        }
    }
}
