using Reqres_API_Testing_CSharp.Base;
using Reqres_API_Testing_CSharp.Constants;
using Reqres_API_Testing_CSharp.Helpers;
using Reqres_API_Testing_CSharp.Models;
using Reqres_API_Testing_CSharp.TestData;
using System.Net;

namespace Reqres_API_Testing_CSharp;

public class UpdateUserTests : ApiTestBase
{
    [Test]
    public async Task UpdateUser_ShouldReturnUpdatedUserData()
    {
        var requestBody = UserTestData.UpdatedUser;

        var response = await PutAsync(ApiEndpoints.UserById(requestBody.Id), requestBody);

        ResponseAssertions.AssertStatusCode(response, HttpStatusCode.OK);
        ResponseAssertions.AssertContentIsNotEmpty(response);

        var updatedUser = DeserializeResponse<UserResponse>(response.Content!);

        Assert.That(updatedUser, Is.Not.Null);
        Assert.That(updatedUser!.Id, Is.EqualTo(requestBody.Id));
        Assert.That(updatedUser.Name, Is.EqualTo(requestBody.Name));
        Assert.That(updatedUser.Username, Is.EqualTo(requestBody.Username));
        Assert.That(updatedUser.Email, Is.EqualTo(requestBody.Email));
    }
}