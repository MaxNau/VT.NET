using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using VT.NET.Internal;
using VT.NET.Responses;
using VT.NET.Responses.Comments;

namespace VT.NET.Endpoints.IocReputationAndEnrichment
{
    /// <summary>
    /// Represents a client for interacting with the comments endpoint of the VirusTotal API.
    /// This class provides methods to retrieve, add, and delete comments related to various objects.
    /// </summary>
    public class VTComments : VTEndpoint, IVTComments
    {
        private readonly VTObjectEndpoints _objectCommentEndpoints;
        private readonly VTObjectTypeDetector _objectTypeDetector;

        /// <summary>
        /// Initializes a new instance of the <see cref="VTComments"/> class.
        /// </summary>
        /// <param name="httpClient">An <see cref="HttpClient"/> instance used for making HTTP requests.</param>
        /// <param name="apiKey">The API key for authenticating requests to the VirusTotal API.</param>
        public VTComments(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
            _objectCommentEndpoints = new VTObjectEndpoints();
            _objectTypeDetector = new VTObjectTypeDetector();
        }

        /// <summary>
        /// Retrieves the latest comments from VirusTotal.
        /// </summary>
        /// <param name="limit">The maximum number of comments to retrieve (default is 10).</param>
        /// <param name="filter">An optional filter to apply to the comments.</param>
        /// <param name="cursor">A cursor for pagination, allowing you to retrieve additional comments.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>A task that represents the asynchronous operation, with a <see cref="VTPagedResponse{CommentObject}"/> as the result.</returns>
        public async Task<VTPagedResponse<CommentObject>> GetLatestCommentsAsync(int limit = 10, string filter = null,
            string cursor = null, CancellationToken cancellationToken = default)
        {
            return await Self.GetAsync<VTPagedResponse<CommentObject>>($"comments{BuildQuery(limit, filter, cursor)}", cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves a specific comment by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the comment to retrieve.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>A task that represents the asynchronous operation, with a <see cref="CommentObject"/> as the result.</returns>
        public async Task<CommentObject> GetCommentAsync(string id, CancellationToken cancellationToken = default)
        {
            var result = await Self.GetAsync<VTResponse<CommentObject>>($"comments/{id}", cancellationToken).ConfigureAwait(false);
            return result.Data;
        }

        /// <summary>
        /// Retrieves a paginated list of comments associated with a specified object.
        /// </summary>
        /// <param name="objectId">The unique identifier of the object for which to retrieve comments.</param>
        /// <param name="objectType">The type of the object (e.g., file, URL, etc.).</param>
        /// <param name="limit">The maximum number of comments to retrieve (default is 10).</param>
        /// <param name="cursor">A cursor for pagination, allowing you to retrieve additional comments.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>A task that represents the asynchronous operation, with a <see cref="VTPagedResponse{CommentObject}"/> as the result.</returns>
        public async Task<VTPagedResponse<CommentObject>> GetCommentsAsync(string objectId, VTObjectType objectType, int limit = 10, string cursor = null, CancellationToken cancellationToken = default)
        {
            return await Self.GetAsync<VTPagedResponse<CommentObject>>($"{_objectCommentEndpoints.Get(objectType)}/{objectId}/comments{BuildQuery(limit, cursor: cursor)}", cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves a paginated list of comments associated with a specified object, determining the object type automatically.
        /// </summary>
        /// <param name="objectId">The unique identifier of the object for which to retrieve comments.</param>
        /// <param name="limit">The maximum number of comments to retrieve (default is 10).</param>
        /// <param name="cursor">A cursor for pagination, allowing you to retrieve additional comments.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>A task that represents the asynchronous operation, with a <see cref="VTPagedResponse{CommentObject}"/> as the result.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the object type cannot be determined.</exception>
        public async Task<VTPagedResponse<CommentObject>> GetCommentsAsync(string objectId, int limit = 10, string cursor = null, CancellationToken cancellationToken = default)
        {
            var objectType = _objectTypeDetector.Detect(objectId);
            if (objectType == null)
            {
                throw new InvalidOperationException($"Unable to determine object type for objectId:{objectId}");
            }

            return await GetCommentsAsync(objectId, objectType.Value, limit, cursor, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Adds a comment to a specified object.
        /// </summary>
        /// <param name="objectId">The unique identifier of the object to which the comment will be added.</param>
        /// <param name="objectType">The type of the object (e.g., file, URL, etc.).</param>
        /// <param name="comment">The text of the comment to add.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>A task that represents the asynchronous operation, with a <see cref="CommentObject"/> as the result.</returns>
        public async Task<CommentObject> AddCommentAsync(string objectId, VTObjectType objectType, string comment, CancellationToken cancellationToken = default)
        {
            var json = JsonSerializer.Serialize(new VTResponse<CreateCommentObject>(new CreateCommentObject(comment)), new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            using (var content = new StringContent(json))
            {
                var response = await Self.PostAsync<VTResponse<CommentObject>>($"{_objectCommentEndpoints.Get(objectType)}/{objectId}/comments", content, cancellationToken).ConfigureAwait(false);
                return response.Data;
            }
        }

        /// <summary>
        /// Adds a comment to a specified object, determining the object type automatically.
        /// </summary>
        /// <param name="objectId">The unique identifier of the object to which the comment will be added.</param>
        /// <param name="comment">The text of the comment to add.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>A task that represents the asynchronous operation, with a <see cref="CommentObject"/> as the result.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the object type cannot be determined.</exception>
        public async Task<CommentObject> AddCommentAsync(string objectId, string comment, CancellationToken cancellationToken = default)
        {
            var objectType = _objectTypeDetector.Detect(objectId);
            if (objectType == null)
            {
                throw new InvalidOperationException($"Unable to determine object type for objectId:{objectId}");
            }

            var json = JsonSerializer.Serialize(new VTResponse<CreateCommentObject>(new CreateCommentObject(comment)), new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            using (var content = new StringContent(json))
            {
                return await AddCommentAsync(objectId, objectType.Value, comment, cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Deletes a specified comment by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the comment to delete.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task DeleteCommentAsync(string id, CancellationToken cancellationToken = default)
        {
            await Self.DeleteAsync($"comments/{id}", cancellationToken).ConfigureAwait(false);
        }
    }
}
