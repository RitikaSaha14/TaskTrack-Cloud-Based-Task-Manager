# TaskTrack — Cloud-Based Task Manager API

A RESTful task management API built with **C#, ASP.NET Core, Entity Framework Core, and SQLite**, with Docker support and a deployment path for Microsoft Azure App Service.

TaskTrack allows users to create, retrieve, update, and delete tasks through HTTP endpoints. It is a beginner-friendly project designed to demonstrate backend development, database integration, API testing, containerization, and cloud deployment.

## Features

- **Task Management:** Create, retrieve, update, and delete tasks.
- **RESTful API:** Implements standard HTTP methods for CRUD operations.
- **Database Integration:** Uses Entity Framework Core with SQLite.
- **Input Validation:** Validates required task titles.
- **Interactive API Documentation:** Uses Swagger UI to test endpoints.
- **Docker Support:** Includes a Dockerfile for containerizing the application.
- **Cloud Deployment:** Prepared for deployment to Azure App Service.

## Tech Stack

| Technology | Purpose |
|---|---|
| C# | Backend programming language |
| ASP.NET Core Minimal APIs | REST API development |
| Entity Framework Core | Database access and ORM |
| SQLite | Local database |
| Swagger / OpenAPI | API documentation and testing |
| Docker | Application containerization |
| Microsoft Azure App Service | Cloud hosting |

## Project Structure

```text
TaskTrack-DotNet-Azure/
├── TaskTrack.Api/
│   ├── Data/
│   │   └── TaskDbContext.cs
│   ├── Models/
│   │   └── TaskItem.cs
│   ├── Program.cs
│   ├── appsettings.json
│   ├── TaskTrack.Api.csproj
│   ├── Dockerfile
│   └── .dockerignore
├── .gitignore
└── README.md
```

## Getting Started

### Prerequisites

Install the following tools before running the project:

- [.NET SDK 10](https://dotnet.microsoft.com/download)
- [Visual Studio Code](https://code.visualstudio.com/) or Visual Studio
- [Git](https://git-scm.com/downloads)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) — optional, for containerization

### 1. Clone the repository

```bash
git clone https://github.com/YOUR_USERNAME/TaskTrack-DotNet-Azure.git
cd TaskTrack-DotNet-Azure
```

Replace `YOUR_USERNAME` with your GitHub username.

### 2. Navigate to the API project

```bash
cd TaskTrack.Api
```

### 3. Restore dependencies

```bash
dotnet restore
```

### 4. Run the application

```bash
dotnet run
```

The terminal will display the local application URL. Open that URL followed by `/swagger` to access the Swagger interface.

For example:

```text
http://localhost:5000/swagger
```

Use the actual URL and port printed by your application.

## API Endpoints

The API supports the following operations:

| HTTP Method | Endpoint | Description |
|---|---|---|
| GET | `/api/tasks` | Retrieve all tasks |
| GET | `/api/tasks/{id}` | Retrieve a task by ID |
| POST | `/api/tasks` | Create a new task |
| PUT | `/api/tasks/{id}` | Update an existing task |
| DELETE | `/api/tasks/{id}` | Delete a task |

### Create a Task

**Request**

```http
POST /api/tasks
Content-Type: application/json
```

**Request body**

```json
{
  "title": "Learn ASP.NET Core",
  "description": "Build my first REST API"
}
```

A successful request returns the created task, including its generated ID and creation timestamp.

### Retrieve All Tasks

```http
GET /api/tasks
```

Returns a JSON array containing the stored tasks.

### Retrieve a Task by ID

```http
GET /api/tasks/1
```

Returns the requested task or a `404 Not Found` response if it does not exist.

### Update a Task

**Request**

```http
PUT /api/tasks/1
Content-Type: application/json
```

**Request body**

```json
{
  "title": "Learn Azure",
  "description": "Deploy my first API",
  "isCompleted": true
}
```

### Delete a Task

```http
DELETE /api/tasks/1
```

Returns `204 No Content` when the task is successfully deleted.

## Run with Docker

Docker allows the API to run inside a container without requiring the .NET SDK in the container's host environment.

Ensure Docker Desktop is running, then execute these commands from the `TaskTrack.Api` directory.

### Build the image

```bash
docker build -t tasktrack-api .
```

### Start the container

```bash
docker run --rm -p 8080:8080 tasktrack-api
```

Open:

```text
http://localhost:8080/swagger
```

**Database note:** The starter version uses SQLite for simplicity. The container's database file is not automatically persisted after the container is removed. For persistent cloud data, configure durable storage or migrate to Azure SQL Database.

## Azure Deployment

TaskTrack is designed to be deployed to **Azure App Service**.

### Deployment steps

1. Push the project to GitHub.
2. Create an Azure App Service web app configured for a compatible .NET runtime, or use a supported custom-container deployment.
3. Deploy the published application or Docker image using an appropriate deployment method.
4. Configure the required application settings and persistent database connection.
5. Open the deployed application's `/swagger` endpoint.
6. Test the CRUD endpoints against the deployed application.

Official documentation: [Deploy an ASP.NET Core app to Azure App Service](https://learn.microsoft.com/en-us/azure/app-service/quickstart-dotnetcore).

> **Important:** The local SQLite configuration is intended for learning. For a production-style Azure deployment, use Azure SQL Database or another suitable persistent database and configure its connection string securely. Confirm the app's runtime and hosting configuration before deployment.

## Testing and Performance Metrics

The following metrics can be measured as the project develops:

| Metric | Measurement method |
|---|---|
| API endpoint coverage | Verify all five endpoints |
| API test pass rate | Passed tests / total tests × 100 |
| Response time | Measure API latency over repeated requests |
| CRUD success rate | Successful valid operations / total valid operations |
| Cloud availability | Successful health checks / total health checks |

Actual measurements should be recorded after testing. No performance benchmarks or deployment results are claimed in advance.

## Future Improvements

- Add automated unit and integration tests.
- Implement pagination, filtering, and sorting.
- Replace SQLite with Azure SQL Database.
- Add authentication and authorization.
- Set up CI/CD using GitHub Actions.
- Add structured logging and application monitoring with Azure Application Insights.
- Add a frontend using React or Blazor.

## Learning Outcomes

This project provides hands-on practice with:

- C# and ASP.NET Core development.
- REST API design and HTTP status codes.
- Entity Framework Core and relational databases.
- API testing with Swagger.
- Docker image creation and container execution.
- Cloud hosting concepts using Microsoft Azure.


