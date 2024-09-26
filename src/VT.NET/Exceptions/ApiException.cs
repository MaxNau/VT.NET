using System;

namespace VT.NET.Exceptions
{
    internal class ApiException : Exception
    {
        public ApiException(int statusCode, string message, string responseBody)
       : base(message)
        {
            StatusCode = statusCode;
            ResponseBody = responseBody;
        }

        public int StatusCode { get; }
        public string ResponseBody { get; }
    }
}
