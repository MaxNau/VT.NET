using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using VT.NET.Internal;
using VT.NET.Responses;
using VT.NET.Responses.Objects.Vote;

namespace VT.NET.Endpoints.IocReputationAndEnrichment
{
    /// <summary>
    /// Represents a client for interacting with the votes endpoint of the VirusTotal API.
    /// This class provides methods to retrieve and add votes related to various objects.
    /// </summary>
    public class VTVotes : VTEndpoint, IVTVotes
    {
        private readonly VTObjectEndpoints _objectEndpoints;
        private readonly VTObjectTypeDetector _objectTypeDetector;

        /// <summary>
        /// Initializes a new instance of the <see cref="VTVotes"/> class.
        /// </summary>
        /// <param name="httpClient">An <see cref="HttpClient"/> instance used for making HTTP requests.</param>
        /// <param name="apiKey">The API key for authenticating requests to the VirusTotal API.</param>
        public VTVotes(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
            _objectEndpoints = new VTObjectEndpoints();
            _objectTypeDetector = new VTObjectTypeDetector();
        }

        /// <summary>
        /// Retrieves a paginated list of votes associated with a specified object.
        /// </summary>
        /// <param name="objectId">The unique identifier of the object for which to retrieve votes.</param>
        /// <param name="objectType">The type of the object (e.g., file, URL, etc.).</param>
        /// <param name="limit">The maximum number of votes to retrieve (default is 10).</param>
        /// <param name="cursor">A cursor for pagination, allowing you to retrieve additional votes.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>A task that represents the asynchronous operation, with a <see cref="VTPagedResponse{VoteObject}"/> as the result.</returns>
        public async Task<VTPagedResponse<VoteObject>> GetVotesAsync(string objectId, VTObjectType objectType, int limit = 10, string cursor = null, CancellationToken cancellationToken = default)
        {
            return await Self.GetAsync<VTPagedResponse<VoteObject>>($"{_objectEndpoints.Get(objectType)}/{objectId}/votes{BuildQuery(limit, cursor: cursor)}", cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves a paginated list of votes associated with a specified object, determining the object type automatically.
        /// </summary>
        /// <param name="objectId">The unique identifier of the object for which to retrieve votes.</param>
        /// <param name="limit">The maximum number of votes to retrieve (default is 10).</param>
        /// <param name="cursor">A cursor for pagination, allowing you to retrieve additional votes.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>A task that represents the asynchronous operation, with a <see cref="VTPagedResponse{VoteObject}"/> as the result.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the object type cannot be determined.</exception>
        public async Task<VTPagedResponse<VoteObject>> GetVotesAsync(string objectId, int limit = 10,
            string cursor = null, CancellationToken cancellationToken = default)
        {
            var objectType = _objectTypeDetector.Detect(objectId);

            if (objectType == null)
            {
                throw new InvalidOperationException($"Unable to determine object type for objectId:{objectId}");
            }

            return await GetVotesAsync(objectId, objectType.Value, limit, cursor, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Adds a vote to a specified object.
        /// </summary>
        /// <param name="objectId">The unique identifier of the object to which the vote will be added.</param>
        /// <param name="objectType">The type of the object (e.g., file, URL, etc.).</param>
        /// <param name="verdict">The verdict to associate with the vote (e.g., malicious, harmless, etc.).</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>A task that represents the asynchronous operation, with a <see cref="VoteObject"/> as the result.</returns>
        public async Task<VoteObject> AddVoteAsync(string objectId, VTObjectType objectType, Verdict verdict, CancellationToken cancellationToken = default)
        {
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            var json = JsonSerializer.Serialize(new VTResponse<CreateVote>(new CreateVote(verdict)), options);

            using (var content = new StringContent(json))
            {
                var response = await Self.PostAsync<VTResponse<VoteObject>>($"{_objectEndpoints.Get(objectType)}/{objectId}/votes", content, cancellationToken).ConfigureAwait(false);
                return response.Data;
            }
        }

        /// <summary>
        /// Adds a vote to a specified object, determining the object type automatically.
        /// </summary>
        /// <param name="objectId">The unique identifier of the object to which the vote will be added.</param>
        /// <param name="verdict">The verdict to associate with the vote (e.g., malicious, harmless, etc.).</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>A task that represents the asynchronous operation, with a <see cref="VoteObject"/> as the result.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the object type cannot be determined.</exception>
        public async Task<VoteObject> AddVoteAsync(string objectId, Verdict verdict, CancellationToken cancellationToken = default)
        {
            var objectType = _objectTypeDetector.Detect(objectId);
            if (objectType == null)
            {
                throw new InvalidOperationException($"Unable to determine object type for objectId:{objectId}");
            }

            var json = JsonSerializer.Serialize(new VTResponse<CreateVote>(new CreateVote(verdict)), new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            using (var content = new StringContent(json))
            {
                return await AddVoteAsync(objectId, objectType.Value, verdict, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
