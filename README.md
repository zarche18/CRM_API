# Project Name

Brief description or overview of your ASP.NET Core project.

## Prerequisites

- [.NET SDK 8](https://dotnet.microsoft.com/download)
- [Visual Studio Code](https://code.visualstudio.com/) or [Visual Studio](https://visualstudio.microsoft.com/)

## Getting Started

1. Clone the repository:

    ```bash
    git clone https://github.com/your-username/your-repo.git
    ``` 

2. Apply database migrations:

    To create a new migration:

    ```bash
    add-migration GoFive_CRM
    ```

    ```bash
    update-database
    ```
    More details on EF Core Migrations: [Entity Framework Core Migrations](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)

4. Build and run the application:

    ```bash
    dotnet build
    dotnet run
    ```

## Usage

### JWT Token

To obtain a JWT token for testing, use the following credentials:

- Username: `testuser`
- Password: `testpassword`

Make a POST request to the token endpoint with these credentials to receive a valid token.

```http
POST /api/Auth/login
Content-Type: application/json

{
    "username": "testuser",
    "password": "testpassword"
}
