using System.IO;

namespace VT.NET.Validators
{
    internal interface IVTFilesValidator
    {
        FileValidationResult ValidateFile(string filePath);
        FileValidationResult ValidateStream(Stream stream);
        bool ValidateHash(string hash);
    }
}
