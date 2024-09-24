namespace VT.NET.Constants
{
    internal static class SupportedFileSizes
    {
        public readonly static long RegularFileSizeLimit = 31 << FileSize.MB;
        public readonly static long LargeFileSizeLimit = 649 << FileSize.MB;
    }
}
