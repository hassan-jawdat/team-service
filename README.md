# Team Service

ASP.NET Core Web API for managing team members in the Shiko LMS.

## Endpoints

| Method | Route | Description |
|--------|-------|-------------|
| GET | `/api/team` | Get all team members |
| POST | `/api/team/invite` | Invite a new member by email |
| DELETE | `/api/team/{id}` | Remove a team member |

## Run locally

```bash
dotnet run
```

API runs on `http://localhost:5093`

## API Documentation

Swagger UI available at `http://localhost:5093/swagger`

## Tech Stack

- .NET 9
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
