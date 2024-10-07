namespace VT.NET
{
    /// <summary>
    /// Represents the possible verdicts that can be assigned to an object in the VirusTotal API.
    /// </summary>
    public enum Verdict
    {
        /// <summary>
        /// Indicates that the object is considered harmless.
        /// </summary>
        Harmless,

        /// <summary>
        /// Indicates that the object is considered malicious.
        /// </summary>
        Malicious
    }
}
