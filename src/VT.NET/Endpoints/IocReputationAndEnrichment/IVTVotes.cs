using System.Threading.Tasks;
using System.Threading;
using System;
using VT.NET.Responses.Objects.Vote;
using VT.NET.Responses;

namespace VT.NET.Endpoints.IocReputationAndEnrichment
{
    /// <summary>
    /// Provides an interface to interact with the votes endpoint of the VirusTotal API.
    /// This interface provides methods to retrieve and add votes related to various objects.
    /// </summary>
    public interface IVTVotes
    {
        /// <summary>
        /// Retrieves a paginated list of votes associated with a specified object.
        /// </summary>
        /// <param name="objectId">The unique identifier of the object for which to retrieve votes.</param>
        /// <param name="objectType">The type of the object (e.g., file, URL, etc.).</param>
        /// <param name="limit">The maximum number of votes to retrieve (default is 10).</param>
        /// <param name="cursor">A cursor for pagination, allowing you to retrieve additional votes.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>A task that represents the asynchronous operation, with a <see cref="VTPagedResponse{VoteObject}"/> as the result.</returns>
        Task<VTPagedResponse<VoteObject>> GetVotesAsync(string objectId, VTObjectType objectType, int limit = 10, string cursor = null, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Retrieves a paginated list of votes associated with a specified object, determining the object type automatically.
        /// </summary>
        /// <param name="objectId">The unique identifier of the object for which to retrieve votes.</param>
        /// <param name="limit">The maximum number of votes to retrieve (default is 10).</param>
        /// <param name="cursor">A cursor for pagination, allowing you to retrieve additional votes.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>A task that represents the asynchronous operation, with a <see cref="VTPagedResponse{VoteObject}"/> as the result.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the object type cannot be determined.</exception>
        Task<VTPagedResponse<VoteObject>> GetVotesAsync(string objectId, int limit = 10,
            string cursor = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a vote to a specified object.
        /// </summary>
        /// <param name="objectId">The unique identifier of the object to which the vote will be added.</param>
        /// <param name="objectType">The type of the object (e.g., file, URL, etc.).</param>
        /// <param name="verdict">The verdict to associate with the vote (e.g., malicious, harmless, etc.).</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>A task that represents the asynchronous operation, with a <see cref="VoteObject"/> as the result.</returns>
        Task<VoteObject> AddVoteAsync(string objectId, VTObjectType objectType, Verdict verdict, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a vote to a specified object, determining the object type automatically.
        /// </summary>
        /// <param name="objectId">The unique identifier of the object to which the vote will be added.</param>
        /// <param name="verdict">The verdict to associate with the vote (e.g., malicious, harmless, etc.).</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>A task that represents the asynchronous operation, with a <see cref="VoteObject"/> as the result.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the object type cannot be determined.</exception>
        Task<VoteObject> AddVoteAsync(string objectId, Verdict verdict, CancellationToken cancellationToken = default);
    }
}
