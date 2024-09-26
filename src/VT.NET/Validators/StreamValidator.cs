using System;
using System.IO;
using VT.NET.Constants;

namespace VT.NET.Validators
{
    internal class StreamValidator : IValidator<Stream>
    {
        public ValidationResult Validate(Stream stream)
        {
            if (stream == null || stream.Length == 0)
            {
                return new ValidationResult(new ArgumentException("Stream is null or empty"));
            }

            if (stream.Length == SupportedFileSizes.LargeFileSizeLimit)
            {
                return new ValidationResult(new InvalidOperationException("Max file size limit is 650MB"));
            }

            return new ValidationResult();
        }
    }
}
