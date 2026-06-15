using Reqres_API_Testing_CSharp.Base;
using Reqres_API_Testing_CSharp.Constants;
using Reqres_API_Testing_CSharp.Helpers;
using Reqres_API_Testing_CSharp.Models;
using Reqres_API_Testing_CSharp.TestData;
using System.Net;

namespace Reqres_API_Testing_CSharp.Tests;

public class UsersTests : ApiTestBase
{
    [Test]
    public async Task GetUsers_ShouldReturnSuccessStatusCode()
    {
        var response = await GetAsync(ApiEndpoints.Users);

        ResponseAssertions.AssertStatusCode(response, HttpStatusCode.OK);
        ResponseAssertions.AssertContentIsNotEmpty(response);

        var users = DeserializeResponse<List<UserResponse>>(response.Content!);

        Assert.That(users, Is.Not.Null);
        Assert.That(users!, Has.Count.EqualTo(10));
    }

    [Test]
    public async Task GetSingleUser_ShouldReturnUserDetails()
    {
        var response = await GetAsync(ApiEndpoints.UserById(UserTestData.ExistingUserId));

        ResponseAssertions.AssertStatusCode(response, HttpStatusCode.OK);
        ResponseAssertions.AssertContentIsNotEmpty(response);

        var user = DeserializeResponse<UserResponse>(response.Content!);

        Assert.That(user, Is.Not.Null);
        Assert.That(user!.Name, Is.EqualTo(UserTestData.ExpectedUserName));
        Assert.That(user.Username, Is.EqualTo(UserTestData.ExpectedUsername));
        Assert.That(user.Email, Is.EqualTo(UserTestData.ExpectedUserEmail));
    }

    [Test]
    public async Task GetSingleUser_WithInvalidId_ShouldReturnNotFound()
    {
        var response = await GetAsync(ApiEndpoints.UserById(UserTestData.NonExistingUserId));

        ResponseAssertions.AssertStatusCode(response, HttpStatusCode.NotFound);
    }
}