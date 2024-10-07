using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Analysis
{
    /// <summary>
    /// Represents the analysis of a file, URL etc in the VirusTotal service.
    /// </summary>
    /// <remarks>
    /// The <see cref="AnalysisObject"/> class inherits from <see cref="VTObject"/> and 
    /// provides information related to the analysis type and identifiers for files, 
    /// URLs etc analyzed by VirusTotal.
    /// </remarks>
    public class AnalysisObject : VTObject
    {
        [JsonConstructor]
        internal AnalysisObject(string type, string id, Links links) : base(type, id, links) { }
    }
}
