﻿using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Files
{
    /// <summary>
    /// Represents a detailed report of a file analysis from the VirusTotal API response.
    /// </summary>
    /// <remarks>
    /// The <see cref="FileObject"/> class inherits from <see cref="VTObject"/> 
    /// and includes additional attributes that provide more insights into the file analysis results.
    /// </remarks>
    public class FileObject : VTObject
    {
        internal FileObject() { }

        [JsonConstructor]
        internal FileObject(string id, string type, Links links, FileObjectAttributes attributes)
            : base(id, type, links)
        {
            Attributes = attributes;
        }

        /// <summary>
        /// Gets the attributes containing detailed information about the file analysis.
        /// </summary>
        /// <value>
        /// An <see cref="Attributes"/> object that includes various statistics and details regarding the file's analysis results.
        /// </value>
        public FileObjectAttributes Attributes { get; }
    }
}
