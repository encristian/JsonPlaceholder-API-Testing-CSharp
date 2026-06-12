using Reqres_API_Testing_CSharp.Base;
using Reqres_API_Testing_CSharp.Constants;
using Reqres_API_Testing_CSharp.Models;
using RestSharp;
using System.Net;

namespace Reqres_API_Testing_CSharp;

public class UsersTests : ApiTestBase
{
    [Test]
    public async Task GetUsers_ShouldReturnSuccessStatusCode()
    {
        using var client = CreateClient();

        var request = new RestRequest(ApiEndpoints.Users, Method.Get);

        var response = await client.ExecuteAsync(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content, Is.Not.Null.And.Not.Empty);

        var users = DeserializeResponse<List<UserResponse>>(response.Content!);

        Assert.That(users, Is.Not.Null);
        Assert.That(users!, Has.Count.EqualTo(10));
    }

    [Test]
    public async Task GetSingleUser_ShouldReturnUserDetails()
    {
        using var client = CreateClient();

        var request = new RestRequest(ApiEndpoints.UserById(1), Method.Get);

        var response = await client.ExecuteAsync(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content, Is.Not.Null.And.Not.Empty);

        var user = DeserializeResponse<UserResponse>(response.Content!);

        Assert.That(user, Is.Not.Null);
        Assert.That(user!.Name, Is.EqualTo("Leanne Graham"));
        Assert.That(user.Username, Is.EqualTo("Bret"));
        Assert.That(user.Email, Is.EqualTo("Sincere@april.biz"));
    }

    [Test]
    public async Task GetSingleUser_WithInvalidId_ShouldReturnNotFound()
    {
        using var client = CreateClient();

        var request = new RestRequest(ApiEndpoints.UserById(999), Method.Get);

        var response = await client.ExecuteAsync(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }
}