# JsonPlaceholder API Testing Framework - C# RestSharp NUnit

This is an API automation testing project built with **C#**, **RestSharp** and **NUnit**.

The project tests the main API flows from the JSONPlaceholder demo API:

https://jsonplaceholder.typicode.com/

---

## Project Purpose

The purpose of this project is to demonstrate basic QA Automation skills using **C#**, **RestSharp** and **NUnit**.

This project covers:

* API automation testing
* GET, POST, PUT and DELETE requests
* Positive API test scenarios
* Negative API test scenarios
* Status code validation
* Response body validation
* Request models
* Response models
* Test data separation
* Reusable helper methods
* Assertion helper structure
* Query parameter testing
* Git version control

---

## Background

I have over 3 years of experience in QA and created this project to practice and demonstrate API Automation skills using C#, RestSharp and NUnit.

This project is part of my QA Automation portfolio and is intended to showcase my ability to write automated API tests, structure a test automation framework and use version control with Git.

---

## Technologies Used

* C#
* .NET
* NUnit
* RestSharp
* System.Text.Json
* Visual Studio
* Git
* GitHub

---

## Test Scenarios Covered

### GET Tests

* Verify that all users can be retrieved
* Verify that a single user can be retrieved by ID
* Verify user details from the API response
* Verify that a non-existing user returns `404 Not Found`
* Verify users can be filtered using query parameters

### POST Tests

* Create a new user
* Verify `201 Created` status code
* Verify response body after creating a user
* Verify generated user ID

### PUT Tests

* Update an existing user
* Verify `200 OK` status code
* Verify updated user data in the response body

### DELETE Tests

* Delete a user
* Verify successful delete response

### Negative Tests

* Verify invalid endpoint returns `404 Not Found`
* Verify invalid user ID format returns `404 Not Found`

---

## Project Structure

```text
JsonPlaceholder-API-Testing-CSharp/
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
│   ├── CreateUserTests.cs
│   ├── DeleteUserTests.cs
│   ├── NegativeUserTests.cs
│   ├── QueryUserTests.cs
│   ├── UpdateUserTests.cs
│   └── UsersTests.cs
│
├── .gitignore
├── README.md
└── Reqres-API-Testing-CSharp.csproj
```

---

## ApiTestBase

The project uses an `ApiTestBase` class to store shared setup and reusable helper methods.

`ApiTestBase` contains:

* Base API URL
* GET helper method
* POST helper method
* PUT helper method
* DELETE helper method
* JSON deserialization helper method

This reduces duplicated code inside test classes and makes the tests easier to read and maintain.

---

## Models

The project uses models to keep request and response data organized.

### Request Models

* `CreateUserRequest.cs` is used when creating a new user
* `UpdateUserRequest.cs` is used when updating an existing user

### Response Models

* `UserResponse.cs` is used to deserialize and validate user data from API responses

This makes the tests cleaner because the JSON response is converted into C# objects.

---

## Helpers

The project uses a `ResponseAssertions` helper class for common response validations.

`ResponseAssertions` contains:

* Status code validation
* Response content validation

This keeps the test classes cleaner and avoids repeating the same assertions in multiple tests.

---

## TestData

The project uses a `UserTestData` class to store reusable test data.

`UserTestData` contains:

* Existing user ID
* Non-existing user ID
* Expected user name
* Expected username
* Expected email
* New user test data
* Updated user test data

This separates test data from test logic.

---

## How to Run the Tests

### 1. Clone the repository

```bash
git clone https://github.com/encristian/JsonPlaceholder-API-Testing-CSharp.git
```

### 2. Open the project folder

```bash
cd JsonPlaceholder-API-Testing-CSharp
```

### 3. Restore dependencies

```bash
dotnet restore
```

### 4. Run the tests

```bash
dotnet test
```

---

## Test Status

```text
Passed: 10
```

The project currently contains 10 automated API tests.

---

## What I Learned

Through this project, I practiced:

* Writing automated API tests
* Using RestSharp with C#
* Using NUnit assertions
* Testing GET, POST, PUT and DELETE requests
* Validating HTTP status codes
* Validating JSON response body data
* Creating request models
* Creating response models
* Refactoring duplicated code
* Creating reusable helper methods
* Creating assertion helper classes
* Separating test data from test logic
* Testing positive and negative API scenarios
* Testing query parameters
* Using Git commits
* Structuring a QA Automation portfolio project

---

## Author

Created as part of my QA Automation portfolio.
