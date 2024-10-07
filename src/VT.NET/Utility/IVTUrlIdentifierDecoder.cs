using System;

namespace VT.NET.Utility
{
    internal interface IVTUrlIdentifierDecoder
    {
        Uri DecodeUrlFromBase64(string encodedUri);
    }
}
