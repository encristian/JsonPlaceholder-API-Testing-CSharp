using RestSharp;

namespace Reqres_API_Testing_CSharp.Base;

public class ApiTestBase
{
    protected const string BaseUrl = "https://jsonplaceholder.typicode.com";

    protected RestClient CreateClient()
    {
        return new RestClient(BaseUrl);
    }
}