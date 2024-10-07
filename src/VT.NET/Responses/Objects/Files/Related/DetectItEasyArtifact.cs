using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Files.Related
{
    /// <summary>
    /// Details of the artifact detected in the file
    /// </summary>
    public class DetectItEasyArtifact
    {
        internal DetectItEasyArtifact() { }

        [JsonConstructor]
        internal DetectItEasyArtifact(string info, string version, string type, string name)
        {
            Info = info;
            Version = version;
            Type = type;
            Name = name;
        }

        /// <summary>
        /// Context of the artifact(i.e. "Native", "GUI32", "NRV", etc).
        /// </summary>
        public string Info { get; }

        /// <summary>
        /// Version
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// General type of detection("Linker", "Compiler", "Packer", etc).
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Item specific name("UPX", "Microsoft Linker", "gcc(GNU)", etc).
        /// </summary>
        public string Name { get; }
    }
}
