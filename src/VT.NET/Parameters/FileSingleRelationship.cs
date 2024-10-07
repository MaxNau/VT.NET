using VT.NET.Enums.Relationship;

namespace VT.NET.Parameters
{
    /// <summary>
    /// Represents a single relationship specifically for file-related entities.
    /// </summary>
    public class FileSingleRelationship : SingleRelationship<FileRelationship>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileSingleRelationship"/> class.
        /// </summary>
        /// <param name="relationship">The <see cref="FileRelationship"/> that defines the relationship.</param>
        public FileSingleRelationship(FileRelationship relationship)
        {
            Relationship = relationship;
        }
    }
}
