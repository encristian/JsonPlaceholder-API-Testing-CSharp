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

    protected async Task<RestResponse> GetAsync(string endpoint)
    {
        using var client = CreateClient();

        var request = new RestRequest(endpoint, Method.Get);

        return await client.ExecuteAsync(request);
    }

    protected async Task<RestResponse> GetAsync(string endpoint, Dictionary<string, string> queryParameters)
    {
        using var client = CreateClient();

        var request = new RestRequest(endpoint, Method.Get);

        foreach (var parameter in queryParameters)
        {
            request.AddQueryParameter(parameter.Key, parameter.Value);
        }

        return await client.ExecuteAsync(request);
    }

    protected async Task<RestResponse> PostAsync<TRequest>(string endpoint, TRequest body)
        where TRequest : class
    {
        using var client = CreateClient();

        var request = new RestRequest(endpoint, Method.Post);

        request.AddJsonBody(body);

        return await client.ExecuteAsync(request);
    }

    protected async Task<RestResponse> PutAsync<TRequest>(string endpoint, TRequest body)
        where TRequest : class
    {
        using var client = CreateClient();

        var request = new RestRequest(endpoint, Method.Put);

        request.AddJsonBody(body);

        return await client.ExecuteAsync(request);
    }

    protected async Task<RestResponse> DeleteAsync(string endpoint)
    {
        using var client = CreateClient();

        var request = new RestRequest(endpoint, Method.Delete);

        return await client.ExecuteAsync(request);
    }
}