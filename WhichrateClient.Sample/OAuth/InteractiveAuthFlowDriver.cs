using System.Web;
using PuppeteerSharp;

namespace WhichrateClient.Sample.OAuth;

/// <summary>
/// Drives an interactive OAuth 2.0 authentication flow using Puppeteer.
/// Note: Do not use this in a production environment. This code is provided for demo purposes only.
/// </summary>
public class InteractiveAuthFlowDriver
{
    private const string AuthorizeUrl = "https://api.whichrate.co.uk/oauth/authorize";
    private readonly string _clientId;
    private readonly string _redirectUri;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="InteractiveAuthFlowDriver"/>.
    /// </summary>
    /// <param name="clientId">The client identifier.</param>
    /// <param name="redirectUri">The redirect or callback URI.</param>
    public InteractiveAuthFlowDriver(string clientId, string redirectUri)
    {
        _clientId = clientId;
        _redirectUri = redirectUri;
    }
    
    /// <summary>
    /// Get an authorization code using an interactive OAuth 2.0 flow.
    /// </summary>
    /// <param name="username">The username.</param>
    /// <param name="password">The password.</param>
    /// <returns>The authorization code.</returns>
    public async Task<string> GetAuthorizationCode(string username, string password)
    {
        using var browserFetcher = new BrowserFetcher();
        await browserFetcher.DownloadAsync(BrowserFetcher.DefaultChromiumRevision);
        Console.WriteLine("Fetching browser.");
        
        var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });
        var page = await browser.NewPageAsync();
        Console.WriteLine("Launching browser for OAuth 2.0 login flow.");

        await page.GoToAsync($"{AuthorizeUrl}?response_type=code&client_id={_clientId}&redirect_uri={HttpUtility.UrlEncode(_redirectUri)}");
        await page.TypeAsync("#username", username);
        await page.TypeAsync("#password", password);
        await page.ClickAsync("#btn-login");
        
        Console.WriteLine("Waiting for OAuth 2.0 login redirect.");
        await page.WaitForTimeoutAsync(5000);
        
        var uri = new Uri(page.Url);
        var querystring = HttpUtility.ParseQueryString(uri.Query);
        var code = querystring.Get("code");
        if (code is null)
        {
            throw new ArgumentNullException(nameof(code), "Unable to retrieve authorization code.");
        }
        
        return code;
    }
}