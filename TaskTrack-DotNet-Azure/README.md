# TaskTrack — .NET + Azure Task Manager API

A beginner-friendly REST API built with C#, ASP.NET Core Minimal APIs, Entity Framework Core, and SQLite. It can be run locally, containerized with Docker, and deployed to Azure App Service.

## Features

- Create, list, retrieve, update, and delete tasks (CRUD)
- Mark tasks as complete or incomplete
- SQLite database for local development
- Swagger UI for testing endpoints
- Dockerfile for containerizing the API
- Azure App Service deployment path

## Tech stack

- C# / ASP.NET Core (.NET 10)
- REST API / Minimal APIs
- Entity Framework Core
- SQLite
- Swagger / OpenAPI
- Docker
- Azure App Service

## Prerequisites

Install the .NET 10 SDK. To use Docker, install Docker Desktop. Azure deployment requires an Azure subscription; check current pricing before creating resources.

## Run locally

From the repository root:

```bash
cd TaskTrack.Api
dotnet restore
dotnet run
```

Open the URL printed in the terminal and add `/swagger` to open Swagger UI.

## API endpoints

| Method | Endpoint | Purpose |
|---|---|---|
| GET | `/api/tasks` | List all tasks |
| GET | `/api/tasks/{id}` | Get one task |
| POST | `/api/tasks` | Create a task |
| PUT | `/api/tasks/{id}` | Update a task |
| DELETE | `/api/tasks/{id}` | Delete a task |

### Example: create a task

Send a `POST` request to `/api/tasks` with JSON:

```json
{
  "title": "Learn Azure App Service",
  "description": "Deploy my first .NET API"
}
```

### Example: update a task

Send a `PUT` request to `/api/tasks/1` with JSON:

```json
{
  "title": "Learn Azure App Service",
  "description": "Deploy my first .NET API",
  "isCompleted": true
}
```

## Run with Docker

From the `TaskTrack.Api` directory:

```bash
docker build -t tasktrack-api .
docker run --rm -p 8080:8080 tasktrack-api
```

Then open `http://localhost:8080/swagger`.

> Note: this starter uses a SQLite file for simplicity. A container's writable filesystem and an App Service filesystem may not provide the durable database storage you want for a production app. For a stronger cloud version, replace SQLite with Azure SQL Database or another managed database and store secrets in App Service configuration.

## Deploy to Azure App Service

1. Push this repository to your GitHub account.
2. In the Azure portal, create a Web App / App Service.
3. Choose a supported .NET runtime and a suitable pricing plan. Availability and pricing of free tiers can change.
4. Deploy the `TaskTrack.Api` project using the Azure App Service extension for VS Code or the Azure portal's supported deployment workflow.
5. Open the deployed app's `/swagger` path and test the endpoints.

Official guide: [Deploy an ASP.NET app to Azure App Service](https://learn.microsoft.com/azure/app-service/quickstart-dotnetcore).

## Suggested improvements

- Add request validation and automated tests
- Add pagination and filtering
- Use Azure SQL for persistent cloud data
- Add GitHub Actions for CI/CD
- Add authentication after learning the basics

## Resume description

**TaskTrack — Cloud-Based Task Manager API**  
Built a RESTful task management API using C#, ASP.NET Core Minimal APIs, Entity Framework Core, and SQLite. Implemented CRUD operations and Swagger-based API testing, added Docker support, and prepared the application for deployment to Azure App Service.

Only claim Azure deployment after you have actually deployed and tested the live application.
