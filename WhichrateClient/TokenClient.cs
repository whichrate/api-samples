using System;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using WhichrateClient.Constants;
using WhichrateClient.Models;

namespace WhichrateClient;

/// <summary>
/// Provides access to the Whichrate token retrieval endpoint.
/// </summary>
public interface ITokenClient
{
    /// <summary>
    /// Request a token from the token endpoint.
    /// </summary>
    /// <param name="request">The token request.</param>
    /// <returns>A <see cref="TokenResponse"/>.</returns>
    Task<TokenResponse> Request(TokenRequest request);
}

/// <inheritdoc />
public sealed class TokenClient : ITokenClient
{
    internal const string BaseUrl = "https://api.whichrate.co.uk/oauth";
    
    /// <inheritdoc />
    public async Task<TokenResponse> Request(TokenRequest request)
    {
        var response = await BaseUrl
            .AppendPathSegment("token")
            .WithHeader(HttpHeaders.ContentTypeHeader, HttpHeaders.ContentTypeFormUrlEncoded)
            .SendUrlEncodedAsync(HttpMethod.Post, CreateRequestUrlEncoded(request));

        return await response.GetJsonAsync<TokenResponse>();
    }

    internal static object CreateRequestUrlEncoded(TokenRequest request) => request.GrantType switch
    {
        GrantTypes.AuthorizationCode => new
        {
            grant_type = request.GrantType,
            code = request.Code,
            client_id = request.ClientId,
            client_secret = request.ClientSecret,
            redirect_uri = request.RedirectUri
        },
        GrantTypes.ClientCredentials => new
        {
            grant_type = request.GrantType,
            client_id = request.ClientId,
            client_secret = request.ClientSecret
        },
        GrantTypes.RefreshToken => new
        {
            grant_type = request.GrantType,
            refresh_token = request.RefreshToken,
            client_id = request.ClientId,
            client_secret = request.ClientSecret
        },
        _ => throw new ArgumentException($"Unsupported grant type '{request.GrantType}'.", nameof(request.GrantType))
    };
}