using Reqres_API_Testing_CSharp.Base;
using Reqres_API_Testing_CSharp.Constants;
using Reqres_API_Testing_CSharp.TestData;
using RestSharp;
using System.Net;

namespace Reqres_API_Testing_CSharp;

public class DeleteUserTests : ApiTestBase
{
    [Test]
    public async Task DeleteUser_ShouldReturnSuccessStatusCode()
    {
        using var client = CreateClient();

        var request = new RestRequest(ApiEndpoints.UserById(UserTestData.ExistingUserId), Method.Delete);

        var response = await client.ExecuteAsync(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
}