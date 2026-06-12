using NUnit.Framework;
using RestSharp;
using System.Net;

namespace Reqres_API_Testing_CSharp.Helpers;

public static class ResponseAssertions
{
    public static void AssertStatusCode(RestResponse response, HttpStatusCode expectedStatusCode)
    {
        Assert.That(response.StatusCode, Is.EqualTo(expectedStatusCode));
    }

    public static void AssertContentIsNotEmpty(RestResponse response)
    {
        Assert.That(response.Content, Is.Not.Null.And.Not.Empty);
    }
}