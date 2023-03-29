// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;
using System.Net.Http.Headers;

var tokenUrl = "https://api.whichrate.co.uk/oauth/token";
var clientId = "{Client Id}";
var clientSecret = "{Client Secret}";

var client = new HttpClient();

//Make the API call to request the token, using the async Task that awaits the result and doesn't block the main thread.
var token = JsonConvert.DeserializeObject<Dictionary<string, object>>(GetTokenAsync().Result)["access_token"].ToString();

//Make the API call for the data.
var request = new HttpRequestMessage(HttpMethod.Get, "https://api.whichrate.co.uk/api/searches");
request.Headers.Add("Authorization", "Bearer " + token);
var content = new StringContent("{\n    \"hire_date\": \"2022-06-07\",\n    \"postcode\": \"ST147JQ\",\n    \"hire_duration\": 10,\n    \"vrn\": \"NL68NMA\",\n    \"automatic\": false,\n    \"DOB\": \"1970-01-01\",\n    \"additional_drivers\": 1\n}", null, "application/json");
request.Content = content;

var response = await client.SendAsync(request);
response.EnsureSuccessStatusCode();

Console.WriteLine(await response.Content.ReadAsStringAsync());

async Task<string> GetTokenAsync()
{
    var content = new FormUrlEncodedContent(new KeyValuePair<string?, string?>[]
    {
        new("client_id", clientId),
        new("client_secret", clientSecret),
        new("grant_type", "client_credentials")
    });

    var tokenRequest = new HttpRequestMessage(HttpMethod.Post, tokenUrl);
    tokenRequest.Content = content;
    tokenRequest.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded") { CharSet = "UTF-8" };

    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(clientId, clientSecret);
    HttpResponseMessage Response = await client.SendAsync(tokenRequest);
    
    Response.EnsureSuccessStatusCode();
    return await Response.Content.ReadAsStringAsync();
}
