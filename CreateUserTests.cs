using Reqres_API_Testing_CSharp.Base;
using Reqres_API_Testing_CSharp.Constants;
using Reqres_API_Testing_CSharp.Models;
using Reqres_API_Testing_CSharp.TestData;
using System.Net;

namespace Reqres_API_Testing_CSharp;

public class CreateUserTests : ApiTestBase
{
    [Test]
    public async Task CreateUser_ShouldReturnCreatedStatusCode()
    {
        var requestBody = UserTestData.NewUser;

        var response = await PostAsync(ApiEndpoints.Users, requestBody);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        Assert.That(response.Content, Is.Not.Null.And.Not.Empty);

        var createdUser = DeserializeResponse<UserResponse>(response.Content!);

        Assert.That(createdUser, Is.Not.Null);
        Assert.That(createdUser!.Name, Is.EqualTo(requestBody.Name));
        Assert.That(createdUser.Username, Is.EqualTo(requestBody.Username));
        Assert.That(createdUser.Email, Is.EqualTo(requestBody.Email));
        Assert.That(createdUser.Id, Is.GreaterThan(0));
    }
}