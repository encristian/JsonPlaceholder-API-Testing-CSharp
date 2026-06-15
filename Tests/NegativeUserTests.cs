using Reqres_API_Testing_CSharp.Base;
using Reqres_API_Testing_CSharp.Constants;
using Reqres_API_Testing_CSharp.Helpers;
using System.Net;

namespace Reqres_API_Testing_CSharp.Tests;

public class NegativeUserTests : ApiTestBase
{
    [Test]
    public async Task GetInvalidEndpoint_ShouldReturnNotFound()
    {
        var response = await GetAsync(ApiEndpoints.InvalidEndpoint);

        ResponseAssertions.AssertStatusCode(response, HttpStatusCode.NotFound);
    }

    [Test]
    public async Task GetUser_WithInvalidIdFormat_ShouldReturnNotFound()
    {
        var response = await GetAsync(ApiEndpoints.UserById("abc"));

        ResponseAssertions.AssertStatusCode(response, HttpStatusCode.NotFound);
    }
}