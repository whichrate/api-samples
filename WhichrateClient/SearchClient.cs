using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using WhichrateClient.Constants;
using WhichrateClient.Models;

namespace WhichrateClient;

/// <summary>
/// Provides access to the Whichrate search endpoint.
/// </summary>
public interface ISearchClient
{
    /// <summary>
    /// Search BHR data with the specified query.
    /// </summary>
    /// <param name="request">The search request with the query parameters.</param>
    /// <returns>A <see cref="IReadOnlyList{SearchResponse}"/>.</returns>
    Task<IReadOnlyList<SearchResponse>> Search(SearchRequest request);
}

/// <inheritdoc />
public sealed class SearchClient : ISearchClient
{
    internal const string BaseUrl = "https://api.whichrate.co.uk/api";
    
    private readonly string _bearerToken;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="SearchClient"/>/
    /// </summary>
    /// <param name="bearerToken">The bearer token.</param>
    public SearchClient(string bearerToken)
    {
        _bearerToken = bearerToken ?? throw new ArgumentNullException(nameof(bearerToken));
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<SearchResponse>> Search(SearchRequest request)
    {
        var response = await BaseUrl
            .AppendPathSegment("searches")
            .WithOAuthBearerToken(_bearerToken)
            .WithHeader(HttpHeaders.ContentTypeHeader, HttpHeaders.ContentTypeJson)
            .SendJsonAsync(HttpMethod.Post, request);

       return await response.GetJsonAsync<IReadOnlyList<SearchResponse>>();
    }
}