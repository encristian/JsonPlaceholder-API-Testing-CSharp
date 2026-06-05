using RestSharp;
using System.Net;

namespace Reqres_API_Testing_CSharp;

public class UsersTests
{
    [Test]
    public async Task GetUsers_ShouldReturnSuccessStatusCode()
    {
        var client = new RestClient("https://jsonplaceholder.typicode.com");

        var request = new RestRequest("/users", Method.Get);

        var response = await client.ExecuteAsync(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
}