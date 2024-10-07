using System.Threading.Tasks;
using System.Threading;
using VT.NET.Responses.Comments;
using VT.NET.Responses;
using System;

namespace VT.NET.Endpoints.IocReputationAndEnrichment
{
    /// <summary>
    /// Provides interface for interacting with the comments endpoint of the VirusTotal API.
    /// This interface provides methods to retrieve, add, and delete comments related to various objects.
    /// </summary>
    public interface IVTComments
    {
        /// <summary>
        /// Retrieves the latest comments from VirusTotal.
        /// </summary>
        /// <param name="limit">The maximum number of comments to retrieve (default is 10).</param>
        /// <param name="filter">An optional filter to apply to the comments.</param>
        /// <param name="cursor">A cursor for pagination, allowing you to retrieve additional comments.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>A task that represents the asynchronous operation, with a <see cref="VTPagedResponse{CommentObject}"/> as the result.</returns>
        Task<VTPagedResponse<CommentObject>> GetLatestCommentsAsync(int limit = 10, string filter = null,
            string cursor = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a specific comment by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the comment to retrieve.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>A task that represents the asynchronous operation, with a <see cref="CommentObject"/> as the result.</returns>
        Task<CommentObject> GetCommentAsync(string id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a paginated list of comments associated with a specified object.
        /// </summary>
        /// <param name="objectId">The unique identifier of the object for which to retrieve comments.</param>
        /// <param name="objectType">The type of the object (e.g., file, URL, etc.).</param>
        /// <param name="limit">The maximum number of comments to retrieve (default is 10).</param>
        /// <param name="cursor">A cursor for pagination, allowing you to retrieve additional comments.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>A task that represents the asynchronous operation, with a <see cref="VTPagedResponse{CommentObject}"/> as the result.</returns>
        Task<VTPagedResponse<CommentObject>> GetCommentsAsync(string objectId, VTObjectType objectType, int limit = 10, string cursor = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a paginated list of comments associated with a specified object, determining the object type automatically.
        /// </summary>
        /// <param name="objectId">The unique identifier of the object for which to retrieve comments.</param>
        /// <param name="limit">The maximum number of comments to retrieve (default is 10).</param>
        /// <param name="cursor">A cursor for pagination, allowing you to retrieve additional comments.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>A task that represents the asynchronous operation, with a <see cref="VTPagedResponse{CommentObject}"/> as the result.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the object type cannot be determined.</exception>
        Task<VTPagedResponse<CommentObject>> GetCommentsAsync(string objectId, int limit = 10, string cursor = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a comment to a specified object.
        /// </summary>
        /// <param name="objectId">The unique identifier of the object to which the comment will be added.</param>
        /// <param name="objectType">The type of the object (e.g., file, URL, etc.).</param>
        /// <param name="comment">The text of the comment to add.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>A task that represents the asynchronous operation, with a <see cref="CommentObject"/> as the result.</returns>
        Task<CommentObject> AddCommentAsync(string objectId, VTObjectType objectType, string comment, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a comment to a specified object, determining the object type automatically.
        /// </summary>
        /// <param name="objectId">The unique identifier of the object to which the comment will be added.</param>
        /// <param name="comment">The text of the comment to add.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>A task that represents the asynchronous operation, with a <see cref="CommentObject"/> as the result.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the object type cannot be determined.</exception>
        Task<CommentObject> AddCommentAsync(string objectId, string comment, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a specified comment by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the comment to delete.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task DeleteCommentAsync(string id, CancellationToken cancellationToken = default);
    }
}
