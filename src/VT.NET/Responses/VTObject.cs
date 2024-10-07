using System.Text.Json.Serialization;

namespace VT.NET.Responses
{
    /// <summary>
    /// Represents the object in the VirusTotal API response (e.g file, url, comment etc).
    /// </summary>
    public abstract class VTObject
    {
        internal VTObject() { }

        [JsonConstructor]
        internal VTObject(string id, string type, Links links)
        {
            Id = id;
            Type = type;
            Links = links;
        }

        /// <summary>
        /// Type of the VirusTotal object
        /// </summary>
        /// <value>
        /// A string representing the type of the object (e.g., "file").
        /// </value>
        public string Type { get; }

        /// <summary>
        /// Unique identifier for the VirusTotal object.
        /// </summary>
        /// <value>
        /// A string that serves as the unique ID for the object in VirusTotal.
        /// </value>
        public string Id { get; }

        /// <summary>
        /// Gets the links associated with the object.
        /// </summary>
        /// <value>
        /// A <see cref="Links"/> object containing URLs for accessing additional information about the object.
        /// </value>
        public Links Links { get; }
    }
}
