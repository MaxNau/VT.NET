namespace VT.NET
{
    /// <summary>
    /// Represents the various types of objects that can be analyzed by the VirusTotal API.
    /// </summary>
    public enum VTObjectType
    {
        /// <summary>
        /// Indicates a file object type, which represents files submitted for analysis.
        /// </summary>
        File,

        /// <summary>
        /// Indicates a URL object type, which represents web addresses submitted for analysis.
        /// </summary>
        Url,

        /// <summary>
        /// Indicates a domain object type, which represents domain names submitted for analysis.
        /// </summary>
        Domain,

        /// <summary>
        /// Indicates an IP address object type, which represents IP addresses submitted for analysis.
        /// </summary>
        IP
    }
}
