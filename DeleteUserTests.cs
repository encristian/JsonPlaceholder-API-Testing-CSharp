using RestSharp;
using System.Net;

namespace Reqres_API_Testing_CSharp;

public class DeleteUserTests
{
    [Test]
    public async Task DeleteUser_ShouldReturnSuccessStatusCode()
    {
        using var client = new RestClient("https://jsonplaceholder.typicode.com");

        var request = new RestRequest("/users/1", Method.Delete);

        var response = await client.ExecuteAsync(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
}