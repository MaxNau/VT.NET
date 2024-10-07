using System;

namespace VT.NET.Validators
{
    internal class DomainValidator : IValidator<string>
    {
        public ValidationResult Validate(string input)
        {
            if (!input.Contains("."))
                return new ValidationResult(new FormatException("Domain format is not valid"));

            if (string.IsNullOrEmpty(input) || input.Length > 253)
                return new ValidationResult(new FormatException("Domain format is not valid"));

            string[] labels = input.Split('.');
            foreach (var label in labels)
            {
                if (string.IsNullOrEmpty(label) || label.Length > 63)
                    return new ValidationResult(new FormatException("Domain format is not valid"));

                foreach (char c in label)
                {
                    if (!char.IsLetterOrDigit(c) && c != '-')
                        return new ValidationResult(new FormatException("Domain format is not valid"));
                }

                if (label[0] == '-' || label[label.Length - 1] == '-')
                    return new ValidationResult(new FormatException("Domain format is not valid"));
            }

            return new ValidationResult();
        }
    }
}
