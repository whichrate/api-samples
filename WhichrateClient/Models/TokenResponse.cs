using Newtonsoft.Json;

namespace WhichrateClient.Models;

/// <summary>
/// A token response from the WhichRate API.
/// </summary>
public sealed class TokenResponse
{
    /// <summary>
    /// Gets or sets the access token.
    /// </summary>
    [JsonProperty("access_token")]
    public string AccessToken { get; set; }
        
    /// <summary>
    /// Gets or sets the token type.
    /// </summary>
    [JsonProperty("token_type")]
    public string TokenType { get; set; }
        
    /// <summary>
    /// Gets or sets the token expiry time in seconds.
    /// </summary>
    [JsonProperty("expires_in")]
    public int ExpiresIn { get; set; }
        
    /// <summary>
    /// Gets or sets the token scope.
    /// </summary>
    [JsonProperty("scope")]
    public string Scope { get; set; }
    
    /// <summary>
    /// Gets or sets the refresh token.
    /// </summary>
    [JsonProperty("refresh_token")]
    public string RefreshToken { get; set; }
}