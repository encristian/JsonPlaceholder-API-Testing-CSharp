JSONPlaceholder API Testing Framework - C# RestSharp NUnit

This project is an API automation testing framework built with C#, NUnit, and RestSharp.

The purpose of this project is to demonstrate API testing fundamentals such as GET, POST, PUT, DELETE requests, response validation, status code checks, request models, response models, test data management, and clean test structure.

The tested API is:

https://jsonplaceholder.typicode.com
Technologies Used
C#
.NET
NUnit
RestSharp
System.Text.Json
Git
GitHub
Project Structure
Reqres-API-Testing-CSharp/
│
├── Base/
│   └── ApiTestBase.cs
│
├── Constants/
│   └── ApiEndpoints.cs
│
├── Helpers/
│   └── ResponseAssertions.cs
│
├── Models/
│   ├── CreateUserRequest.cs
│   ├── UpdateUserRequest.cs
│   └── UserResponse.cs
│
├── TestData/
│   └── UserTestData.cs
│
├── Tests/
│   ├── UsersTests.cs
│   ├── CreateUserTests.cs
│   ├── UpdateUserTests.cs
│   ├── DeleteUserTests.cs
│   ├── NegativeUserTests.cs
│   └── QueryUserTests.cs
│
├── README.md
└── Reqres-API-Testing-CSharp.csproj
Test Coverage

This project contains automated API tests for the following scenarios:

GET Requests
Get all users
Get a single user by ID
Get a non-existing user
Get users by query parameter
POST Requests
Create a new user
Validate response status code
Validate response body
Validate generated user ID
PUT Requests
Update an existing user
Validate updated user data
DELETE Requests
Delete a user
Validate successful delete response
Negative Tests
Invalid endpoint returns 404 Not Found
Invalid user ID format returns 404 Not Found
Current Test Status
Passed: 10

The project currently contains 10 automated API tests.

How to Run the Tests

Clone the repository:

git clone <repository-url>

Navigate to the project folder:

cd Reqres-API-Testing-CSharp

Restore dependencies:

dotnet restore

Run the tests:

dotnet test
Main Concepts Practiced

This project demonstrates:

API testing with C#
NUnit test structure
RestSharp request execution
GET, POST, PUT, DELETE methods
HTTP status code validation
JSON response validation
Request models
Response models
Test data separation
Helper methods
Assertion helpers
Query parameters
Negative API testing
Git version control
Example Test
[Test]
public async Task GetSingleUser_ShouldReturnUserDetails()
{
    var response = await GetAsync(ApiEndpoints.UserById(UserTestData.ExistingUserId));

    ResponseAssertions.AssertStatusCode(response, HttpStatusCode.OK);
    ResponseAssertions.AssertContentIsNotEmpty(response);

    var user = DeserializeResponse<UserResponse>(response.Content!);

    Assert.That(user, Is.Not.Null);
    Assert.That(user!.Name, Is.EqualTo(UserTestData.ExpectedUserName));
    Assert.That(user.Username, Is.EqualTo(UserTestData.ExpectedUsername));
    Assert.That(user.Email, Is.EqualTo(UserTestData.ExpectedUserEmail));
}
Notes

JSONPlaceholder is a fake online REST API used for testing and learning. POST, PUT, and DELETE requests return simulated responses, but the data is not permanently saved on the server.

This project is created for learning and portfolio purposes.