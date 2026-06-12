using Reqres_API_Testing_CSharp.Base;
using Reqres_API_Testing_CSharp.Constants;
using Reqres_API_Testing_CSharp.Models;
using RestSharp;
using System.Net;

namespace Reqres_API_Testing_CSharp;

public class UpdateUserTests : ApiTestBase
{
    [Test]
    public async Task UpdateUser_ShouldReturnUpdatedUserData()
    {
        using var client = CreateClient();

        var request = new RestRequest(ApiEndpoints.UserById(1), Method.Put);

        var requestBody = new UpdateUserRequest
        {
            Id = 1,
            Name = "Chris Updated",
            Username = "chrisupdated",
            Email = "chris.updated@example.com"
        };

        request.AddJsonBody(requestBody);

        var response = await client.ExecuteAsync(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content, Is.Not.Null.And.Not.Empty);

        var updatedUser = DeserializeResponse<UserResponse>(response.Content!);

        Assert.That(updatedUser, Is.Not.Null);
        Assert.That(updatedUser!.Id, Is.EqualTo(1));
        Assert.That(updatedUser.Name, Is.EqualTo("Chris Updated"));
        Assert.That(updatedUser.Username, Is.EqualTo("chrisupdated"));
        Assert.That(updatedUser.Email, Is.EqualTo("chris.updated@example.com"));
    }
}