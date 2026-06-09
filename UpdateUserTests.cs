using Reqres_API_Testing_CSharp.Base;
using RestSharp;
using System.Net;
using System.Text.Json;

namespace Reqres_API_Testing_CSharp;

public class UpdateUserTests : ApiTestBase
{
    [Test]
    public async Task UpdateUser_ShouldReturnUpdatedUserData()
    {
        using var client = CreateClient();

        var request = new RestRequest("/users/1", Method.Put);

        request.AddJsonBody(new
        {
            id = 1,
            name = "Chris Updated",
            username = "chrisupdated",
            email = "chris.updated@example.com"
        });

        var response = await client.ExecuteAsync(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content, Is.Not.Null.And.Not.Empty);

        using JsonDocument json = JsonDocument.Parse(response.Content!);

        int id = json.RootElement.GetProperty("id").GetInt32();
        string name = json.RootElement.GetProperty("name").GetString()!;
        string username = json.RootElement.GetProperty("username").GetString()!;
        string email = json.RootElement.GetProperty("email").GetString()!;

        Assert.That(id, Is.EqualTo(1));
        Assert.That(name, Is.EqualTo("Chris Updated"));
        Assert.That(username, Is.EqualTo("chrisupdated"));
        Assert.That(email, Is.EqualTo("chris.updated@example.com"));
    }
}