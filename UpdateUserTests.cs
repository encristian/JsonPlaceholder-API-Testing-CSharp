using Reqres_API_Testing_CSharp.Base;
using Reqres_API_Testing_CSharp.Constants;
using Reqres_API_Testing_CSharp.Models;
using Reqres_API_Testing_CSharp.TestData;
using RestSharp;
using System.Net;

namespace Reqres_API_Testing_CSharp;

public class UpdateUserTests : ApiTestBase
{
    [Test]
    public async Task UpdateUser_ShouldReturnUpdatedUserData()
    {
        using var client = CreateClient();

        var requestBody = UserTestData.UpdatedUser;

        var request = new RestRequest(ApiEndpoints.UserById(requestBody.Id), Method.Put);

        request.AddJsonBody(requestBody);

        var response = await client.ExecuteAsync(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content, Is.Not.Null.And.Not.Empty);

        var updatedUser = DeserializeResponse<UserResponse>(response.Content!);

        Assert.That(updatedUser, Is.Not.Null);
        Assert.That(updatedUser!.Id, Is.EqualTo(requestBody.Id));
        Assert.That(updatedUser.Name, Is.EqualTo(requestBody.Name));
        Assert.That(updatedUser.Username, Is.EqualTo(requestBody.Username));
        Assert.That(updatedUser.Email, Is.EqualTo(requestBody.Email));
    }
}