namespace Reqres_API_Testing_CSharp.Constants;

public static class ApiEndpoints
{
    public const string Users = "/users";

    public static string UserById(int id)
    {
        return $"/users/{id}";
    }
}