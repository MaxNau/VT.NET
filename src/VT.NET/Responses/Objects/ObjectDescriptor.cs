using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects
{
    /// <summary>
    /// Represents a descriptor for an object within the VirusTotal API.
    /// </summary>
    /// <remarks>
    /// An ObjectDescriptor contains the essential information required to identify an object,
    /// including its type and unique identifier. This class is typically used in contexts
    /// where relationships between various objects in the VirusTotal API need to be established.
    /// </remarks>
    public class ObjectDescriptor
    {
        internal ObjectDescriptor() { }

        [JsonConstructor]
        internal ObjectDescriptor(string type, string id)
        {
            Type = type;
            Id = id;
        }


        /// <summary>
        /// Type of the object.
        /// </summary>
        /// <remarks>
        /// The type indicates the category of the object, such as "file", "url", "domain",
        /// or "ip". This helps in understanding the nature of the object in the VirusTotal API.
        /// </remarks>
        public string Type { get; }

        /// <summary>
        /// Unique identifier for the object.
        /// </summary>
        public string Id { get; }
    }
}
