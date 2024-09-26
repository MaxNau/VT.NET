namespace VT.NET.Validators
{
    internal interface IValidator<T>
    {
        ValidationResult Validate(T input);
    }
}
