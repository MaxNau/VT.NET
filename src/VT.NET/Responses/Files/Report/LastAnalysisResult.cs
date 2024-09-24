using System.Text.Json.Serialization;

namespace VT.NET.Responses.Files.FileReport
{
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

        public string Method { get; }
        public string EngineName { get; }
        public string EngineVersion { get; }
        public long EngineUpdate { get; }
        public string Category { get; }
        public object Result { get; }
    }
}
