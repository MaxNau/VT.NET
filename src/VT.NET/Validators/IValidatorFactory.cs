using System;

namespace VT.NET.Validators
{
    internal interface IValidatorFactory
    {
        IValidator<T> Get<T>(Type type);
    }
}
