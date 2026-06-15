using Reqres_API_Testing_CSharp.Base;
using Reqres_API_Testing_CSharp.Constants;
using Reqres_API_Testing_CSharp.Helpers;
using Reqres_API_Testing_CSharp.TestData;
using System.Net;

namespace Reqres_API_Testing_CSharp.Tests;

public class DeleteUserTests : ApiTestBase
{
    [Test]
    public async Task DeleteUser_ShouldReturnSuccessStatusCode()
    {
        var response = await DeleteAsync(ApiEndpoints.UserById(UserTestData.ExistingUserId));

        ResponseAssertions.AssertStatusCode(response, HttpStatusCode.OK);
    }
}