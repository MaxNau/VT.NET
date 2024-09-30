using System.Text.Json.Serialization;

namespace VT.NET.Responses.Files.FileReport
{
    /// <summary>
    /// Represents a detailed report of a file analysis from the VirusTotal API response.
    /// </summary>
    /// <remarks>
    /// The <see cref="FileReport"/> class inherits from <see cref="VTObject"/> 
    /// and includes additional attributes that provide more insights into the file analysis results.
    /// </remarks>
    public class FileReport : VTObject
    {
        internal FileReport() { }

        [JsonConstructor]
        internal FileReport(string id, string type, Links links, FileAttributes attributes)
            : base(type, id, links)
        {
            Attributes = attributes;
        }

        /// <summary>
        /// Gets the attributes containing detailed information about the file analysis.
        /// </summary>
        /// <value>
        /// An <see cref="Attributes"/> object that includes various statistics and details regarding the file's analysis results.
        /// </value>
        public FileAttributes Attributes { get; }
    }
}
