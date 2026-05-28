# Team Service

ASP.NET Core Web API for managing team members in the Shiko LMS.

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- SQL Server LocalDB (included with Visual Studio, or install [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads))

## Getting Started

```bash
# 1. Clone the repo
git clone https://github.com/hassan-jawdat/team-service
cd team-service

# 2. Apply database migrations
dotnet ef database update

# 3. Start the API
dotnet run
```

API runs on `http://localhost:5093`

## API Documentation

Swagger UI available at `http://localhost:5093/swagger`

## Endpoints

| Method | Route | Description |
|--------|-------|-------------|
| GET | `/api/team` | Get all team members |
| POST | `/api/team/invite` | Invite a new member by email |
| DELETE | `/api/team/{id}` | Remove a team member |

## Running Tests

```bash
cd TeamService.Tests
dotnet test
```

6 unit tests covering invite, get, and delete functionality.

## Tech Stack

- .NET 9
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server LocalDB
