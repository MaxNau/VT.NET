using VT.NET.Utility;
using VT.NET.Validators;

namespace VT.NET.Internal
{
    internal class VTObjectTypeDetector
    {
        private readonly IValidator<string> _ipValidator;
        private readonly IValidator<string> _fileHashValidator;
        private readonly IVTUrlIdentifierDecoder _identifierGenerator;
        private readonly IValidator<string> _domainValidator;
        internal VTObjectTypeDetector()
        {
            var validatorFactory = new ValidatorFactory();
            _ipValidator = validatorFactory.Get<string>(typeof(IPAddressValidator));
            _fileHashValidator = validatorFactory.Get<string>(typeof(FileHashValidator));
            _identifierGenerator = new VTUrlIdentifierGenerator();
            _domainValidator = validatorFactory.Get<string>(typeof(DomainValidator));
        }

        internal VTObjectType? Detect(string objectId)
        {
            if (string.IsNullOrWhiteSpace(objectId))
            {
                return null;
            }

            if (_ipValidator.Validate(objectId).IsValid)
            {
                return VTObjectType.IP;
            }

            if (_fileHashValidator.Validate(objectId).IsValid)
            {
                return VTObjectType.File;
            }

            if (_domainValidator.Validate(objectId).IsValid)
            {
                return VTObjectType.Domain;
            }

            if (_identifierGenerator.DecodeUrlFromBase64(objectId) != null)
            {
                return VTObjectType.Url;
            }

            return null;
        }
    }
}
