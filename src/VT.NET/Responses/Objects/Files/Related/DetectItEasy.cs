using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Files.Related
{
    /// <summary>
    /// Detect It Easy, or abbreviated "DIE" is a program for determining types of
    /// files.The program defines the types MSDOS, PE, ELF, MACH and Binary.
    /// </summary>
    public class DetectItEasy
    {
        internal DetectItEasy() { }

        [JsonConstructor]
        internal DetectItEasy(string filetype, IEnumerable<DetectItEasyArtifact> values)
        {
            Filetype = filetype;
            Values = values;
        }

        /// <summary>
        /// "PE32", "PE64", "ELF32", "ELF64", "Mach-O64".
        /// </summary>
        public string Filetype { get; }

        /// <summary>
        /// List of artifacts detected in the file. 
        /// </summary>
        public IEnumerable<DetectItEasyArtifact> Values { get; }
    }
}
