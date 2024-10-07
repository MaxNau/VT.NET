using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using VT.NET.Extensions;
using VT.NET.Internal;
using VT.NET.Parameters;
using VT.NET.Responses;
using VT.NET.Responses.Objects;

namespace VT.NET.Endpoints.IocReputationAndEnrichment
{
    /// <summary>
    /// Represents a client for interacting with the objects endpoint of the VirusTotal API.
    /// This class provides methods to retrieve various types of objects and their relationships.
    /// </summary>
    public class VTObjects : VTEndpoint, IVTObjects
    {
        private readonly VTRelationshipToCollectionMap _relationshipToCollectionMap;

        /// <summary>
        /// Initializes a new instance of the <see cref="VTObjects"/> class.
        /// </summary>
        /// <param name="httpClient">An <see cref="HttpClient"/> instance used for making HTTP requests.</param>
        /// <param name="apiKey">The API key for authenticating requests to the VirusTotal API.</param>
        public VTObjects(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
            _relationshipToCollectionMap = new VTRelationshipToCollectionMap();
        }

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
        public async Task<VTObjectWithRelationships<T>> GetObjectDescriptorsAsync<T>(string objectId, ManyRelationship relationship,
            int limit = 10, string cursor = null, CancellationToken cancellationToken = default) where T : VTObjectAttributes
        {
            var relationshipsQuery = $"?relationships={relationship.RelationshipsInternal.ToCommaSeparatedString(JsonNamingPolicy.SnakeCaseLower)}";
            var response = await Self.GetAsync<VTResponse<VTObjectWithRelationships<T>>>(
                $"{_relationshipToCollectionMap.Get(relationship)}/{objectId}{BuildQuery(limit, cursor: cursor, anotherQuery: relationshipsQuery)}", cancellationToken).ConfigureAwait(false);

            return response.Data;
        }

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
        public async Task<VTPagedResponse<ObjectDescriptor>> GetObjectDescriptorsAsync(string objectId, SingleRelationship relationship,
           int limit = 10, string cursor = null, CancellationToken cancellationToken = default)
        {
            return await Self.GetAsync<VTPagedResponse<ObjectDescriptor>>(
                $"{_relationshipToCollectionMap.Get(relationship)}/{objectId}/relationships/{relationship.RelationshipInternal.ToString(JsonNamingPolicy.SnakeCaseLower)}{BuildQuery(limit, cursor: cursor)}",
                cancellationToken).ConfigureAwait(false);
        }

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
        public async Task<VTPagedResponse<T>> GetRelatedObjectsAsync<T>(string objectId, SingleRelationship relationship,
            int limit = 10, string cursor = null, CancellationToken cancellationToken = default) where T : VTObject
        {
            return await Self.GetAsync<VTPagedResponse<T>>(
                $"{_relationshipToCollectionMap.Get(relationship)}/{objectId}/{relationship.RelationshipInternal.ToString(JsonNamingPolicy.SnakeCaseLower)}{BuildQuery(limit, cursor: cursor)}", cancellationToken).ConfigureAwait(false);
        }
    }
}
