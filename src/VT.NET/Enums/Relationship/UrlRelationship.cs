namespace VT.NET.Enums.Relationship
{
    /// <summary>
    /// Represents the various relationships associated with a URL object.
    /// </summary>
    public enum UrlRelationship
    {
        /// <summary>
        /// Analyses for the URL. Accessible to VT Enterprise users only.
        /// </summary>
        Analyses,

        /// <summary>
        /// Community posted comments about the URL. Accessible to everyone.
        /// </summary>
        Comments,

        /// <summary>
        /// Files that communicate with a given URL when they're executed. Accessible to VT Enterprise users only.
        /// </summary>
        CommunicatingFiles,

        /// <summary>
        /// Domains from which the URL loads some kind of resource. Accessible to VT Enterprise users only.
        /// </summary>
        ContactedDomains,

        /// <summary>
        /// IPs from which the URL loads some kind of resource. Accessible to VT Enterprise users only.
        /// </summary>
        ContactedIps,

        /// <summary>
        /// Files downloaded from the URL. Accessible to VT Enterprise users only.
        /// </summary>
        DownloadedFiles,

        /// <summary>
        /// Graphs including the URL. Accessible to everyone.
        /// </summary>
        Graphs,

        /// <summary>
        /// Last IP address that served the URL. Accessible to everyone.
        /// </summary>
        LastServingIpAddress,

        /// <summary>
        /// Domain or IP for the URL. Accessible to everyone.
        /// </summary>
        NetworkLocation,

        /// <summary>
        /// Files containing the URL. Accessible to VT Enterprise users only.
        /// </summary>
        ReferrerFiles,

        /// <summary>
        /// URLs referring to the URL. Accessible to VT Enterprise users only.
        /// </summary>
        ReferrerUrls,

        /// <summary>
        /// URLs that redirected to the given URL. Accessible to VT Enterprise users only.
        /// </summary>
        RedirectingUrls,

        /// <summary>
        /// URLs that the URL redirects to. Accessible to VT Enterprise users only.
        /// </summary>
        RedirectsTo,

        /// <summary>
        /// Community posted comments in the URL's related objects. Accessible to everyone.
        /// </summary>
        RelatedComments,

        /// <summary>
        /// References related to the URL. Accessible to VT Enterprise users only.
        /// </summary>
        RelatedReferences,

        /// <summary>
        /// Threat actors related to the URL. Accessible to VT Enterprise users only.
        /// </summary>
        RelatedThreatActors,

        /// <summary>
        /// URL's submissions. Accessible to VT Enterprise users only.
        /// </summary>
        Submissions
    }
}