using Reqres_API_Testing_CSharp.Base;
using Reqres_API_Testing_CSharp.Constants;
using Reqres_API_Testing_CSharp.TestData;
using System.Net;

namespace Reqres_API_Testing_CSharp;

public class DeleteUserTests : ApiTestBase
{
    [Test]
    public async Task DeleteUser_ShouldReturnSuccessStatusCode()
    {
        var response = await DeleteAsync(ApiEndpoints.UserById(UserTestData.ExistingUserId));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
}