using RestSharp;
using System.Text.Json;

namespace Reqres_API_Testing_CSharp.Base;

public class ApiTestBase
{
    protected const string BaseUrl = "https://jsonplaceholder.typicode.com";

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    protected RestClient CreateClient()
    {
        return new RestClient(BaseUrl);
    }

    protected T? DeserializeResponse<T>(string responseContent)
    {
        return JsonSerializer.Deserialize<T>(responseContent, JsonOptions);
    }
}