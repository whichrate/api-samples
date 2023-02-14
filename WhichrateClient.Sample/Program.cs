// See https://aka.ms/new-console-template for more information

using ServiceStack.Text;
using WhichrateClient;
using WhichrateClient.Models;
using WhichrateClient.Sample.OAuth;
using WhichrateClient.Sample.Storage;

// Replace these with values provided by Whichrate.
const string ClientId = "{Client Id}";
const string ClientSecret = "{Client Secret}";
const string Username = "{Username}";
const string Password = "{Password}";
const string RedirectUri = "https://api.whichrate.co.uk/auth/callback";

// Get the token.
// Note: Interactive authentication flow is provided for demo purposes only and is not intended for production use.
var token = await GetTokenUsingInteractiveAuthFlow();
token.PrintDump();

// Make the search request.
var searchClient = new SearchClient(token.AccessToken);
var searchRequest = new SearchRequest()
{
    HireDate = "2022-05-29",
    Postcode = "NL68 NMA",
    HireDuration = 10,
    Vrn = "AV60ZDS",
    Automatic = false,
    AdditionalDrivers = 1
};
var searchResponse = await searchClient.Search(searchRequest);
searchResponse.PrintDump();
Console.ReadKey();

async Task<TokenResponse> GetTokenUsingInteractiveAuthFlow()
{
    // Gets a token using the interactive authentication flow.
    // Tries to find the token in the cache, otherwise authorizes and retrieves a new token from the API.
    if (JsonCache.TryGetObject<TokenResponse>(nameof(TokenResponse), out var tokenResponse))
    {
        Console.WriteLine("Found cached token.");
        return tokenResponse;
    }
    
    var authFlowDriver = new InteractiveAuthFlowDriver(ClientId, RedirectUri);
    var code = await authFlowDriver.GetAuthorizationCode(Username, Password);
    Console.WriteLine($"Got OAuth 2.0 authorization code '{code}'.");
    
    var tokenClient = new TokenClient();
    var tokenRequest = TokenRequest.FromAuthorizationCode(code, ClientId, ClientSecret, RedirectUri);
    tokenResponse = await tokenClient.Request(tokenRequest);
    Console.WriteLine("Got OAuth 2.0 token via authorization code grant.");

    if (!JsonCache.TryAddObject(nameof(TokenResponse), tokenResponse))
    {
        throw new InvalidOperationException("Failed to cache the token response.");
    }

    Console.WriteLine("Cached OAuth 2.0 token.");
    return tokenResponse;
}

async Task<TokenResponse> GetTokenUsingClientCredentials()
{
    // Gets a token using the client credentials flow.
    // Tries to find the token in the cache, otherwise retrieves a new token from the API.
    if (JsonCache.TryGetObject<TokenResponse>(nameof(TokenResponse), out var tokenResponse))
    {
        Console.WriteLine("Found cached token.");
        return tokenResponse;
    }
    
    var tokenClient = new TokenClient();
    var tokenRequest = TokenRequest.FromClientCredentials(ClientId, ClientSecret);
    tokenResponse = await tokenClient.Request(tokenRequest);
    Console.WriteLine("Got OAuth 2.0 token via client credentials grant.");

    if (!JsonCache.TryAddObject(nameof(TokenResponse), tokenResponse))
    {
        throw new InvalidOperationException("Failed to cache the token response.");
    }

    Console.WriteLine("Cached OAuth 2.0 token.");
    return tokenResponse;
}