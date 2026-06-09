using RestSharp;
using System.Net;
using System.Text.Json;
using Reqres_API_Testing_CSharp.Base;

namespace Reqres_API_Testing_CSharp;

public class UsersTests : ApiTestBase
{
    [Test]
    public async Task GetUsers_ShouldReturnSuccessStatusCode()
    {
        using var client = CreateClient();

        var request = new RestRequest("/users", Method.Get);

        var response = await client.ExecuteAsync(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content, Is.Not.Null.And.Not.Empty);
    }

    [Test]
    public async Task GetSingleUser_ShouldReturnUserDetails()
    {
        using var client = CreateClient();

        var request = new RestRequest("/users/1", Method.Get);

        var response = await client.ExecuteAsync(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content, Is.Not.Null.And.Not.Empty);

        using JsonDocument json = JsonDocument.Parse(response.Content!);

        string name = json.RootElement.GetProperty("name").GetString()!;
        string username = json.RootElement.GetProperty("username").GetString()!;
        string email = json.RootElement.GetProperty("email").GetString()!;

        Assert.That(name, Is.EqualTo("Leanne Graham"));
        Assert.That(username, Is.EqualTo("Bret"));
        Assert.That(email, Is.EqualTo("Sincere@april.biz"));
    }

    [Test]
    public async Task GetSingleUser_WithInvalidId_ShouldReturnNotFound()
    {
        using var client = CreateClient();

        var request = new RestRequest("/users/999", Method.Get);

        var response = await client.ExecuteAsync(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }
}