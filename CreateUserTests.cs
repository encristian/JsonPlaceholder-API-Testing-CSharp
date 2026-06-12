using Reqres_API_Testing_CSharp.Base;
using Reqres_API_Testing_CSharp.Constants;
using Reqres_API_Testing_CSharp.Models;
using RestSharp;
using System.Net;

namespace Reqres_API_Testing_CSharp;

public class CreateUserTests : ApiTestBase
{
    [Test]
    public async Task CreateUser_ShouldReturnCreatedStatusCode()
    {
        using var client = CreateClient();

        var request = new RestRequest(ApiEndpoints.Users, Method.Post);

        var requestBody = new CreateUserRequest
        {
            Name = "Chris Green",
            Username = "chrisgreen",
            Email = "chris.green@example.com"
        };

        request.AddJsonBody(requestBody);

        var response = await client.ExecuteAsync(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        Assert.That(response.Content, Is.Not.Null.And.Not.Empty);

        var createdUser = DeserializeResponse<UserResponse>(response.Content!);

        Assert.That(createdUser, Is.Not.Null);
        Assert.That(createdUser!.Name, Is.EqualTo("Chris Green"));
        Assert.That(createdUser.Username, Is.EqualTo("chrisgreen"));
        Assert.That(createdUser.Email, Is.EqualTo("chris.green@example.com"));
        Assert.That(createdUser.Id, Is.GreaterThan(0));
    }
}