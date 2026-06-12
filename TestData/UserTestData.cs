using Reqres_API_Testing_CSharp.Models;

namespace Reqres_API_Testing_CSharp.TestData;

public static class UserTestData
{
    public const int ExistingUserId = 1;
    public const int NonExistingUserId = 999;

    public const string ExpectedUserName = "Leanne Graham";
    public const string ExpectedUsername = "Bret";
    public const string ExpectedUserEmail = "Sincere@april.biz";

    public static CreateUserRequest NewUser => new CreateUserRequest
    {
        Name = "Chris Green",
        Username = "chrisgreen",
        Email = "chris.green@example.com"
    };

    public static UpdateUserRequest UpdatedUser => new UpdateUserRequest
    {
        Id = 1,
        Name = "Chris Updated",
        Username = "chrisupdated",
        Email = "chris.updated@example.com"
    };
}