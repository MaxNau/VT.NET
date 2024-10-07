namespace VT.NET.Enums.Relationship
{
    /// <summary>
    /// Represents the various relationships associated with a Domain object.
    /// </summary>
    public enum DomainRelationship
    {
        /// <summary>
        /// Records CAA for the domain. Accessible to VT Enterprise users only.
        /// </summary>
        CaaRecords,

        /// <summary>
        /// Records CNAME for the domain. Accessible to VT Enterprise users only.
        /// </summary>
        CnameRecords,

        /// <summary>
        /// Community posted comments about the domain. Accessible to everyone.
        /// </summary>
        Comments,

        /// <summary>
        /// Files that communicate with the domain. Accessible to everyone.
        /// </summary>
        CommunicatingFiles,

        /// <summary>
        /// Files downloaded from that domain. Accessible to VT Enterprise users only.
        /// </summary>
        DownloadedFiles,

        /// <summary>
        /// Graphs including the domain. Accessible to everyone.
        /// </summary>
        Graphs,

        /// <summary>
        /// SSL certificates associated with the domain. Accessible to everyone.
        /// </summary>
        HistoricalSslCertificates,

        /// <summary>
        /// WHOIS information for the domain. Accessible to everyone.
        /// </summary>
        HistoricalWhois,

        /// <summary>
        /// Domain's immediate parent. Accessible to everyone.
        /// </summary>
        ImmediateParent,

        /// <summary>
        /// Records MX for the domain. Accessible to VT Enterprise users only.
        /// </summary>
        MxRecords,

        /// <summary>
        /// Records NS for the domain. Accessible to VT Enterprise users only.
        /// </summary>
        NsRecords,

        /// <summary>
        /// Domain's top parent. Accessible to everyone.
        /// </summary>
        Parent,

        /// <summary>
        /// Files containing the domain. Accessible to everyone.
        /// </summary>
        ReferrerFiles,

        /// <summary>
        /// Community posted comments in the domain's related objects. Accessible to everyone.
        /// </summary>
        RelatedComments,

        /// <summary>
        /// References related to the domain. Accessible to VT Enterprise users only.
        /// </summary>
        RelatedReferences,

        /// <summary>
        /// Threat actors related to the domain. Accessible to VT Enterprise users only.
        /// </summary>
        RelatedThreatActors,

        /// <summary>
        /// DNS resolutions for the domain. Accessible to everyone.
        /// </summary>
        Resolutions,

        /// <summary>
        /// Records SOA for the domain. Accessible to VT Enterprise users only.
        /// </summary>
        SoaRecords,

        /// <summary>
        /// Domain's sibling domains. Accessible to everyone.
        /// </summary>
        Siblings,

        /// <summary>
        /// Domain's subdomains. Accessible to everyone.
        /// </summary>
        Subdomains,

        /// <summary>
        /// URLs having this domain. Accessible to VT Enterprise users only.
        /// </summary>
        Urls,

        /// <summary>
        /// Current user's votes. Accessible to everyone.
        /// </summary>
        UserVotes
    }
}
