using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using Flurl.Http.Testing;
using WhichrateClient.Constants;
using WhichrateClient.Models;
using Xunit;

namespace WhichrateClient.Tests;

/// <summary>
/// Tests for the <see cref="SearchClient"/>.
/// </summary>
public class SearchClientTests
{
    private const string BearerToken = "AYjcyMzY3ZDhiNmJkNTY";

    [Fact]
    public void Ctor_throws_if_bearer_token_is_null()
    {
        Assert.Throws<ArgumentNullException>(() => new SearchClient(null));
    }
    
    [Fact]
    public async Task Search_returns_correct_response()
    {
        using var httpTest = new HttpTest();

        var fixture = new Fixture();
        var request = fixture.Create<SearchRequest>();
        httpTest.RespondWithJson(fixture.Create<IReadOnlyList<SearchResponse>>());
        
        var client = new SearchClient(BearerToken);
        await client.Search(request);

        httpTest.ShouldHaveCalled($"{SearchClient.BaseUrl}/searches")
            .WithVerb(HttpMethod.Get)
            .WithOAuthBearerToken(BearerToken)
            .WithHeader(HttpHeaders.ContentTypeHeader, HttpHeaders.ContentTypeJson)
            .WithRequestJson(request)
            .Times(1);
    }
}