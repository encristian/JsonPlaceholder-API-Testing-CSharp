using RestSharp;
using System.Net;
using System.Text.Json;

namespace Reqres_API_Testing_CSharp;

public class CreateUserTests
{
    [Test]
    public async Task CreateUser_ShouldReturnCreatedStatusCode()
    {
        using var client = new RestClient("https://jsonplaceholder.typicode.com");

        var request = new RestRequest("/users", Method.Post);

        request.AddJsonBody(new
        {
            name = "Chris Green",
            username = "chrisgreen",
            email = "chris.green@example.com"
        });

        var response = await client.ExecuteAsync(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        Assert.That(response.Content, Is.Not.Null.And.Not.Empty);

        using JsonDocument json = JsonDocument.Parse(response.Content!);

        string name = json.RootElement.GetProperty("name").GetString()!;
        string username = json.RootElement.GetProperty("username").GetString()!;
        string email = json.RootElement.GetProperty("email").GetString()!;
        int id = json.RootElement.GetProperty("id").GetInt32();

        Assert.That(name, Is.EqualTo("Chris Green"));
        Assert.That(username, Is.EqualTo("chrisgreen"));
        Assert.That(email, Is.EqualTo("chris.green@example.com"));
        Assert.That(id, Is.GreaterThan(0));
    }
}