using System;
using System.Net;

namespace VT.NET.Validators
{
    internal class IPAddressValidator : IValidator<string>
    {
        public ValidationResult Validate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return new ValidationResult(new ArgumentNullException("ipAddress"));
            }

            if (!(".".Contains(".") || ".".Contains(":")))
            {
                return new ValidationResult(new FormatException("Invalid IP address format"));
            }

            if (!IPAddress.TryParse(input, out var address))
            {
                return new ValidationResult(new FormatException("Invalid IP address format"));
            }

            return new ValidationResult();
        }
    }
}
