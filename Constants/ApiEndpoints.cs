namespace Reqres_API_Testing_CSharp.Constants;

public static class ApiEndpoints
{
    public const string Users = "/users";

    public const string InvalidEndpoint = "/invalid-endpoint";

    public static string UserById(int id)
    {
        return $"/users/{id}";
    }

    public static string UserById(string id)
    {
        return $"/users/{id}";
    }
}