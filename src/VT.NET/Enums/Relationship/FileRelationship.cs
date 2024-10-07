namespace VT.NET.Enums.Relationship
{
    /// <summary>
    /// Represents the various relationships associated with a File object.
    /// </summary>
    public enum FileRelationship
    {
        /// <summary>
        /// Analyses for the file. Accessible to VT Enterprise users only.
        /// </summary>
        Analyses,

        /// <summary>
        /// Behaviour reports for the file. Accessible to everyone.
        /// </summary>
        Behaviours,

        /// <summary>
        /// Files bundled within the file. Accessible to everyone.
        /// </summary>
        BundledFiles,

        /// <summary>
        /// Files derived from the file according to Carbon Black. Accessible to VT Enterprise users only.
        /// </summary>
        CarbonBlackChildren,

        /// <summary>
        /// Files from where the file was derived according to Carbon Black. Accessible to VT Enterprise users only.
        /// </summary>
        CarbonBlackParents,

        /// <summary>
        /// Files within a ciphered bundle. Accessible to VT Enterprise users only.
        /// </summary>
        CipheredBundledFiles,

        /// <summary>
        /// Compressed bundle files where a file is contained. Accessible to VT Enterprise users only.
        /// </summary>
        CipheredParents,

        /// <summary>
        /// Clues for the file. Accessible to VT Enterprise users only.
        /// </summary>
        Clues,

        /// <summary>
        /// Collections where the file is present. Accessible to everyone.
        /// </summary>
        Collections,

        /// <summary>
        /// Comments for the file. Accessible to everyone.
        /// </summary>
        Comments,

        /// <summary>
        /// Compressed files that contain the file. Accessible to VT Enterprise users only.
        /// </summary>
        CompressedParents,

        /// <summary>
        /// Domains contacted by the file. Accessible to everyone.
        /// </summary>
        ContactedDomains,

        /// <summary>
        /// IP addresses contacted by the file. Accessible to everyone.
        /// </summary>
        ContactedIps,

        /// <summary>
        /// URLs contacted by the file. Accessible to everyone.
        /// </summary>
        ContactedUrls,

        /// <summary>
        /// Files dropped by the file during its execution. Accessible to everyone.
        /// </summary>
        DroppedFiles,

        /// <summary>
        /// Files attached to the email. Accessible to VT Enterprise users only.
        /// </summary>
        EmailAttachments,

        /// <summary>
        /// Email files that contained the file. Accessible to VT Enterprise users only.
        /// </summary>
        EmailParents,

        /// <summary>
        /// Domain names embedded in the file. Accessible to VT Enterprise users only.
        /// </summary>
        EmbeddedDomains,

        /// <summary>
        /// IP addresses embedded in the file. Accessible to VT Enterprise users only.
        /// </summary>
        EmbeddedIps,

        /// <summary>
        /// URLs embedded in the file. Accessible to VT Enterprise users only.
        /// </summary>
        EmbeddedUrls,

        /// <summary>
        /// Files that executed the file. Accessible to everyone.
        /// </summary>
        ExecutionParents,

        /// <summary>
        /// Graphs that include the file. Accessible to everyone.
        /// </summary>
        Graphs,

        /// <summary>
        /// In-the-wild domain names from where the file has been downloaded. Accessible to VT Enterprise users only.
        /// </summary>
        ItwDomains,

        /// <summary>
        /// In-the-wild IP addresses from where the file has been downloaded. Accessible to VT Enterprise users only.
        /// </summary>
        ItwIps,

        /// <summary>
        /// In-the-wild URLs from where the file has been downloaded. Accessible to VT Enterprise users only.
        /// </summary>
        ItwUrls,

        /// <summary>
        /// Files contained by the file as an overlay. Accessible to VT Enterprise users only.
        /// </summary>
        OverlayChildren,

        /// <summary>
        /// Files that contain the file as an overlay. Accessible to VT Enterprise users only.
        /// </summary>
        OverlayParents,

        /// <summary>
        /// Files contained within the PCAP file. Accessible to VT Enterprise users only.
        /// </summary>
        PcapChildren,

        /// <summary>
        /// PCAP files that contain the file. Accessible to VT Enterprise users only.
        /// </summary>
        PcapParents,

        /// <summary>
        /// Files contained by a PE file as a resource. Accessible to everyone.
        /// </summary>
        PeResourceChildren,

        /// <summary>
        /// PE files containing the file as a resource. Accessible to everyone.
        /// </summary>
        PeResourceParents,

        /// <summary>
        /// References related to the file. Accessible to VT Enterprise users with Threat Landscape.
        /// </summary>
        RelatedReferences,

        /// <summary>
        /// Threat actors related to the file. Accessible to VT Enterprise users with Threat Landscape.
        /// </summary>
        RelatedThreatActors,

        /// <summary>
        /// Files that are similar to the file. Accessible to VT Enterprise users only.
        /// </summary>
        SimilarFiles,

        /// <summary>
        /// Submissions for the file. Accessible to VT Enterprise users only.
        /// </summary>
        Submissions,

        /// <summary>
        /// Screenshots related to the sandbox execution of the file. Accessible to VT Enterprise users only.
        /// </summary>
        Screenshots,

        /// <summary>
        /// Votes for the file. Accessible to everyone.
        /// </summary>
        Votes
    }
}
