using System.Text.Json.Serialization;

namespace VT.NET.Responses.Files.FileReport
{
    /// <summary>
    /// Represents the result of the last analysis conducted by a specific engine in VirusTotal.
    /// </summary>
    /// <remarks>
    /// The <see cref="LastAnalysisResult"/> class encapsulates the details of the last 
    /// analysis result, including the method used, the engine that performed the analysis, 
    /// and the outcome of the analysis.
    /// </remarks>
    public class LastAnalysisResult
    {
        internal LastAnalysisResult() { }

        [JsonConstructor]
        internal LastAnalysisResult(string method, string engineName, string engineVersion,
            long engineUpdate, string category, object result)
        {
            Method = method;
            EngineName = engineName;
            EngineVersion = engineVersion;
            EngineUpdate = engineUpdate;
            Category = category;
            Result = result;
        }

        /// <summary>
        /// The method used by the engine for analysis.
        /// </summary>
        public string Method { get; }

        /// <summary>
        /// The name of the engine that performed the analysis.
        /// </summary>
        public string EngineName { get; }

        /// <summary>
        /// The version of the engine used for the analysis.
        /// </summary>
        public string EngineVersion { get; }

        /// <summary>
        /// The update timestamp of the engine.
        /// </summary>
        public long EngineUpdate { get; }

        /// <summary>
        /// The category of the analysis result (e.g., malicious, clean).
        /// </summary>
        public string Category { get; }

        /// <summary>
        /// The specific result returned by the engine.
        /// </summary>
        public object Result { get; }
    }
}
