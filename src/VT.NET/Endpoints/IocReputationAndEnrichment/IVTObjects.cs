using System.Threading.Tasks;
using System.Threading;
using VT.NET.Parameters;
using VT.NET.Responses.Objects;
using VT.NET.Responses;

namespace VT.NET.Endpoints.IocReputationAndEnrichment
{
    /// <summary>
    /// Provides an interface for interacting with the objects endpoint of the VirusTotal API.
    /// This interface provides methods to retrieve various types of objects and their relationships.
    /// </summary>
    public interface IVTObjects
    {
        /// <summary>
        /// Retrieves a collection of objects with their relationships for a specified object ID and relationship type.
        /// </summary>
        /// <typeparam name="T">The type of the object attributes being retrieved.</typeparam>
        /// <param name="objectId">The unique identifier of the object whose relationships are being queried.</param>
        /// <param name="relationship">The type of relationship to retrieve.</param>
        /// <param name="limit">The maximum number of related objects to retrieve (default is 10).</param>
        /// <param name="cursor">A cursor for pagination, allowing you to retrieve additional related objects.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>A task that represents the asynchronous operation, with a <see cref="VTObjectWithRelationships{T}"/> as the result.</returns>
        Task<VTObjectWithRelationships<T>> GetObjectDescriptorsAsync<T>(string objectId, ManyRelationship relationship,
            int limit = 10, string cursor = null, CancellationToken cancellationToken = default) where T : VTObjectAttributes;

        /// <summary>
        /// Retrieves a paginated list of object descriptors for a specified object ID and relationship type.
        /// </summary>
        /// <param name="objectId">The unique identifier of the object whose descriptors are being queried.</param>
        /// <param name="relationship">The type of relationship for which object descriptors are being retrieved.</param>
        /// <param name="limit">The maximum number of object descriptors to retrieve (default is 10).</param>
        /// <param name="cursor">A cursor for pagination, allowing you to retrieve additional descriptors if available.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>
        /// A task that represents the asynchronous operation, with a <see cref="VTPagedResponse{ObjectDescriptor}"/> 
        /// containing the paginated list of object descriptors as the result.
        /// </returns>
        Task<VTPagedResponse<ObjectDescriptor>> GetObjectDescriptorsAsync(string objectId, SingleRelationship relationship,
           int limit = 10, string cursor = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a specific related object for a specified object ID and relationship type.
        /// </summary>
        /// <typeparam name="T">The type of the related object being retrieved.</typeparam>
        /// <param name="objectId">The unique identifier of the object whose related object is being queried.</param>
        /// <param name="relationship">The type of relationship to retrieve.</param>
        /// <param name="limit">The maximum number of related objects to retrieve (default is 10).</param>
        /// <param name="cursor">A cursor for pagination, allowing you to retrieve additional related objects.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>A task that represents the asynchronous operation, with a <see cref="VTPagedResponse{T}"/> as the result.</returns>
        Task<VTPagedResponse<T>> GetRelatedObjectsAsync<T>(string objectId, SingleRelationship relationship,
            int limit = 10, string cursor = null, CancellationToken cancellationToken = default) where T : VTObject;
    }
}
