using System;
using System.Collections.Generic;

namespace VT.NET.Validators
{
    internal class ValidatorFactory : IValidatorFactory
    {
        private readonly Dictionary<Type, object> _validators = new Dictionary<Type, object>();

        public ValidatorFactory()
        {
            _validators.Add(typeof(FileHashValidator), new FileHashValidator());
            _validators.Add(typeof(FilePathValidator), new FilePathValidator());
            _validators.Add(typeof(FileSizeValidator), new FileSizeValidator());
            _validators.Add(typeof(StreamValidator), new StreamValidator());
            _validators.Add(typeof(VTFileValidator), new VTFileValidator(this));
            _validators.Add(typeof(IPAddressValidator), new IPAddressValidator());
            _validators.Add(typeof(DomainValidator), new DomainValidator());
        }

        public IValidator<T> Get<T>(Type type)
        {
            if (!_validators.TryGetValue(type, out var validator))
            {
                throw new InvalidOperationException($"Validator not found {type}");
            }

            return (IValidator<T>)validator;
        }
    }
}
