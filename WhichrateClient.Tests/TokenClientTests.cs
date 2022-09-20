using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using Flurl.Http.Testing;
using WhichrateClient.Constants;
using WhichrateClient.Models;
using Xunit;

namespace WhichrateClient.Tests;

/// <summary>
/// Tests for the <see cref="TokenClient"/>.
/// </summary>
public class TokenClientTests
{
    [Fact]
    public async Task Request_from_authorization_code_returns_correct_response()
    {
        using var httpTest = new HttpTest();

        var fixture = new Fixture();
        var request = TokenRequest.FromAuthorizationCode(fixture.Create<string>(), fixture.Create<string>(), fixture.Create<string>(), fixture.Create<string>());
        httpTest.RespondWithJson(fixture.Create<TokenResponse>());
        
        var client = new TokenClient();
        await client.Request(request);

        httpTest.ShouldHaveCalled($"{TokenClient.BaseUrl}/token")
            .WithVerb(HttpMethod.Post)
            .WithHeader(HttpHeaders.ContentTypeHeader, HttpHeaders.ContentTypeFormUrlEncoded)
            .WithRequestUrlEncoded(TokenClient.CreateRequestUrlEncoded(request))
            .Times(1);
    }
    
    [Fact]
    public async Task Request_from_client_credentials_returns_correct_response()
    {
        using var httpTest = new HttpTest();

        var fixture = new Fixture();
        var request = TokenRequest.FromClientCredentials(fixture.Create<string>(), fixture.Create<string>());
        httpTest.RespondWithJson(fixture.Create<TokenResponse>());
        
        var client = new TokenClient();
        await client.Request(request);

        httpTest.ShouldHaveCalled($"{TokenClient.BaseUrl}/token")
            .WithVerb(HttpMethod.Post)
            .WithHeader(HttpHeaders.ContentTypeHeader, HttpHeaders.ContentTypeFormUrlEncoded)
            .WithRequestUrlEncoded(TokenClient.CreateRequestUrlEncoded(request))
            .Times(1);
    }
    
    [Fact]
    public async Task Request_from_refresh_token_returns_correct_response()
    {
        using var httpTest = new HttpTest();

        var fixture = new Fixture();
        var request = TokenRequest.FromRefreshToken(fixture.Create<string>(), fixture.Create<string>(), fixture.Create<string>());
        httpTest.RespondWithJson(fixture.Create<TokenResponse>());
        
        var client = new TokenClient();
        await client.Request(request);

        httpTest.ShouldHaveCalled($"{TokenClient.BaseUrl}/token")
            .WithVerb(HttpMethod.Post)
            .WithHeader(HttpHeaders.ContentTypeHeader, HttpHeaders.ContentTypeFormUrlEncoded)
            .WithRequestUrlEncoded(TokenClient.CreateRequestUrlEncoded(request))
            .Times(1);
    }
}