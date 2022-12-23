# Loan API

* [About](#About)
* [Technologies](#Technologies)
* [Models](#models)
* [Installation](#Installation)

## About
This is a simple loan API that allows users to register, view their information, and apply for loans. The API has the following features:

- User registration
- View user information
- Apply for different types of loans (fast loan, auto loan, instalment loan)
- View loan history
- Update and delete loan applications (only if the status is "Processing")

The API is built with a solid architecture that preserves the separation of concerns and uses design patterns to improve maintainability and extensibility. The application has built-in logging and request validation, and it is covered by tests. The API also uses OpenAPI for documentation and follows clean coding principles.

## Technologies
* [ASP.NET Core 7](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core)
* [Entity Framework Core 7](https://docs.microsoft.com/en-us/ef/core/)
* [MediatR](https://github.com/jbogard/MediatR)
* [FluentValidation](https://fluentvalidation.net/)
* [NUnit](https://nunit.org/), [Moq](https://github.com/moq)



## Models

Each Model have the following fields:

| User Fields | Loan Fields                         |
|-------------|-------------------------------------|
| FirstName   | Type : (Express, Auto, Installment) |
| LastName    | Amount                              |
| Age         | Currency                            |
| Email       | Period                              |
| Income      | Status : (Processing, Approved)     |



## Installation

To create an installation guide for a C# web API, you can follow these steps:

1. Prerequisites:

   - Make sure you have the latest version of .NET Core installed on your machine.
   - Install a text editor or development environment of your choice, such as Visual Studio or Jetbrains Rider.

2. Clone or download the repository:
   - Navigate to the repository where the web API code is hosted (e.g. on GitHub).
   - Click the "Clone or download" button and copy the URL. 
   - Open a terminal and navigate to the directory where you want to clone the repository.
   - Run the following command to clone the repository:
   ```bash
     git clone https://github.com/ananidze/loan_api.git
   ```

3. Database Migrations

   * `--project src/Infrastructure`
   * `--startup-project src/WebUI`

   For example, to add a new migration from the root folder:
   
   `dotnet ef migrations add "SampleMigration" --project src\Infrastructure --startup-project src\WebUI`

4. Build and run the project:

   - Open the project in your text editor or development environment.
   - Build the project by selecting "Build > Build Solution" from the menu.
   - Run the project by selecting "Debug > Start Without Debugging" from the menu.

5. Test the API:

   - To test the API, you can use a tool like Postman or curl.
   - Send a request to the API using the appropriate method (e.g. GET, POST, PUT, DELETE) and verify that the expected response is returned.


## Overview

### Domain

   - This will contain all entities, enums, exceptions, types and logic specific to the domain layer.

### Application

   - This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project.

### Infrastructure

   - This layer contains classes for accessing external resources such as file systems, web services and so on.

### WebUI

   - This layer depends on both the Application and Infrastructure layers
