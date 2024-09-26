using System.Text.Json.Serialization;

namespace VT.NET.Responses
{
    internal class VTResponse<T>
    {
        internal VTResponse() { }

        [JsonConstructor]
        internal VTResponse(T data)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
