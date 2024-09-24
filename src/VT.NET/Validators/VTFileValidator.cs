namespace VT.NET.Validators
{
    internal class VTFileValidator : IValidator<string>
    {
        private readonly IValidatorFactory _validatorFactory;
        public VTFileValidator(IValidatorFactory validatorFactory)
        {
            _validatorFactory = validatorFactory;
        }

        public ValidationResult Validate(string filePath)
        {
            var filePathValidator = _validatorFactory.Get<string>(typeof(FilePathValidator));
            var filePathValidationResult =  filePathValidator.Validate(filePath);
            if (!filePathValidationResult.IsValid)
            {
                return filePathValidationResult;
            }

            var fileSizeValidator = _validatorFactory.Get<string>(typeof(FileSizeValidator));
            return fileSizeValidator.Validate(filePath);
        }
    }
}
