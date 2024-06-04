# POC-Simple-API-Test

Jim Wei practice POC implementation for a simple .NET API, using .NET 8.

## Notes:

This repo sets up a simple ASP.NET Core API and corresponding xUnit test project.

This POC includes creating a new web API project, setting up a test project, adding necessary references, and installing required packages.

## Steps:

# New Web API Project

dotnet new webapi -n SimpleApiTest
cd SimpleApiTest
dotnet run

# New Test Project

cd ..
dotnet new xunit -n SimpleApiTest.Tests
cd SimpleApiTest.Tests

# Add Project Reference to Test Project

dotnet add reference ../SimpleApiTest/SimpleApiTest.csproj
dotnet add package Microsoft.AspNetCore.Mvc.Testing
