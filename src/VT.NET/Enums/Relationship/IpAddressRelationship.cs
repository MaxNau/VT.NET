namespace VT.NET.Enums.Relationship
{
    /// <summary>
    /// Represents the various relationships associated with an IP address object.
    /// </summary>
    public enum IpAddressRelationship
    {
        /// <summary>
        /// Comments for the IP address. Accessible to everyone.
        /// </summary>
        Comments,

        /// <summary>
        /// Files that communicate with the IP address. Accessible to everyone.
        /// </summary>
        CommunicatingFiles,

        /// <summary>
        /// Files downloaded from the IP address. Accessible only to VT Enterprise users.
        /// </summary>
        DownloadedFiles,

        /// <summary>
        /// Graphs including the IP address. Accessible to everyone.
        /// </summary>
        Graphs,

        /// <summary>
        /// SSL certificates associated with the IP address. Accessible to everyone.
        /// </summary>
        HistoricalSslCertificates,

        /// <summary>
        /// WHOIS information for the IP address. Accessible to everyone.
        /// </summary>
        HistoricalWhois,

        /// <summary>
        /// Community posted comments in the IP's related objects. Accessible to everyone.
        /// </summary>
        RelatedComments,

        /// <summary>
        /// References related to the IP address. Accessible only to VT Enterprise users.
        /// </summary>
        RelatedReferences,

        /// <summary>
        /// Threat actors related to the IP address. Accessible only to VT Enterprise users.
        /// </summary>
        RelatedThreatActors,

        /// <summary>
        /// Files containing the IP address. Accessible to everyone.
        /// </summary>
        ReferrerFiles,

        /// <summary>
        /// Resolutions for the IP address. Accessible to everyone.
        /// </summary>
        Resolutions,

        /// <summary>
        /// URLs related to the IP address. Accessible only to VT Enterprise users.
        /// </summary>
        Urls
    }
}
