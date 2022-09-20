using WhichrateClient.Constants;

namespace WhichrateClient.Models;

/// <summary>
/// A token request made to the WhichRate API.
/// </summary>
public sealed class TokenRequest
{
    /// <summary>
    /// Gets or sets the grant type.
    /// </summary>
    public string GrantType { get; set; }
    
    /// <summary>
    /// Gets or sets the refresh token.
    /// </summary>
    public string RefreshToken { get; set; }
        
    /// <summary>
    /// Gets or sets the authorisation code.
    /// </summary>
    public string Code { get; set; }
        
    /// <summary>
    /// Gets or sets the client identifier.
    /// </summary>
    public string ClientId { get; set; }
        
    /// <summary>
    /// Gets or sets the client secret.
    /// </summary>
    public string ClientSecret { get; set; }
    
    /// <summary>
    /// Gets or sets the redirect URI.
    /// </summary>
    public string RedirectUri { get; set; }

    private TokenRequest()
    {
    }
    
    /// <summary>
    /// Create an OAuth 2.0 token request from an authorization code.
    /// </summary>
    /// <param name="code">The authorization code.</param>
    /// <param name="clientId">The client identifier.</param>
    /// <param name="clientSecret">The client secret.</param>
    /// <param name="redirectUri">The redirect URI</param>
    /// <returns>A <see cref="TokenRequest"/>.</returns>
    public static TokenRequest FromAuthorizationCode(string code, string clientId, string clientSecret, string redirectUri) => new()
    {
        GrantType = GrantTypes.AuthorizationCode,
        Code = code,
        ClientId = clientId,
        ClientSecret = clientSecret,
        RedirectUri = redirectUri
    };
    
    /// <summary>
    /// Create an OAuth 2.0 token request from client credentials.
    /// </summary>
    /// <param name="clientId">The client identifier.</param>
    /// <param name="clientSecret">The client secret.</param>
    /// <returns>A <see cref="TokenRequest"/>.</returns>
    public static TokenRequest FromClientCredentials(string clientId, string clientSecret) => new()
    {
        GrantType = GrantTypes.ClientCredentials,
        ClientId = clientId,
        ClientSecret = clientSecret
    };
    
    /// <summary>
    /// Create an OAuth 2.0 token request from a refresh token.
    /// </summary>
    /// <param name="refreshToken">The refresh token.</param>
    /// <param name="clientId">The client identifier.</param>
    /// <param name="clientSecret">The client secret.</param>
    /// <returns>A <see cref="TokenRequest"/>.</returns>
    public static TokenRequest FromRefreshToken(string refreshToken, string clientId, string clientSecret) => new()
    {
        GrantType = GrantTypes.RefreshToken,
        RefreshToken = refreshToken,
        ClientId = clientId,
        ClientSecret = clientSecret
    };
}