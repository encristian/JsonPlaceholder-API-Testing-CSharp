using Reqres_API_Testing_CSharp.Base;
using Reqres_API_Testing_CSharp.Constants;
using Reqres_API_Testing_CSharp.Helpers;
using Reqres_API_Testing_CSharp.Models;
using Reqres_API_Testing_CSharp.TestData;
using System.Net;

namespace Reqres_API_Testing_CSharp.Tests;

public class QueryUserTests : ApiTestBase
{
    [Test]
    public async Task GetUsers_ByUsername_ShouldReturnMatchingUser()
    {
        var queryParams = new Dictionary<string, string>
        {
            { "username", UserTestData.ExpectedUsername }
        };

        var response = await GetAsync(ApiEndpoints.Users, queryParams);

        ResponseAssertions.AssertStatusCode(response, HttpStatusCode.OK);
        ResponseAssertions.AssertContentIsNotEmpty(response);

        var users = DeserializeResponse<List<UserResponse>>(response.Content!);

        Assert.That(users, Is.Not.Null);
        Assert.That(users!, Has.Count.EqualTo(1));
        Assert.That(users![0].Username, Is.EqualTo(UserTestData.ExpectedUsername));
        Assert.That(users[0].Name, Is.EqualTo(UserTestData.ExpectedUserName));
        Assert.That(users[0].Email, Is.EqualTo(UserTestData.ExpectedUserEmail));
    }

    [Test]
    public async Task GetUsers_ByNonExistingUsername_ShouldReturnEmptyList()
    {
        var queryParams = new Dictionary<string, string>
        {
            { "username", "NuExista" }
        };

        var response = await GetAsync(ApiEndpoints.Users, queryParams);

        ResponseAssertions.AssertStatusCode(response, HttpStatusCode.OK);
        ResponseAssertions.AssertContentIsNotEmpty(response);

        var users = DeserializeResponse<List<UserResponse>>(response.Content!);

        Assert.That(users, Is.Not.Null);
        Assert.That(users!, Is.Empty);
    }
}