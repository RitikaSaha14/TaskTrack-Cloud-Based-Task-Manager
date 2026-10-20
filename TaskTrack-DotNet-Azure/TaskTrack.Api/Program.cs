using Microsoft.EntityFrameworkCore;
using TaskTrack.Api.Data;
using TaskTrack.Api.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("TaskTrack")
    ?? "Data Source=tasktrack.db";

builder.Services.AddDbContext<TaskDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Create the local SQLite database automatically for this beginner project.
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TaskDbContext>();
    db.Database.EnsureCreated();
}

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => Results.Ok(new
{
    name = "TaskTrack API",
    message = "Your task manager API is running.",
    docs = "/swagger"
}));

app.MapGet("/api/tasks", async (TaskDbContext db) =>
    Results.Ok(await db.Tasks.OrderBy(task => task.Id).ToListAsync()));

app.MapGet("/api/tasks/{id:int}", async (int id, TaskDbContext db) =>
{
    var task = await db.Tasks.FindAsync(id);
    return task is null ? Results.NotFound() : Results.Ok(task);
});

app.MapPost("/api/tasks", async (CreateTaskRequest request, TaskDbContext db) =>
{
    if (string.IsNullOrWhiteSpace(request.Title))
        return Results.BadRequest(new { error = "Title is required." });

    var task = new TaskItem
    {
        Title = request.Title.Trim(),
        Description = request.Description?.Trim() ?? "",
        IsCompleted = false,
        CreatedAtUtc = DateTime.UtcNow
    };

    db.Tasks.Add(task);
    await db.SaveChangesAsync();

    return Results.Created($"/api/tasks/{task.Id}", task);
});

app.MapPut("/api/tasks/{id:int}", async (int id, UpdateTaskRequest request, TaskDbContext db) =>
{
    var task = await db.Tasks.FindAsync(id);
    if (task is null)
        return Results.NotFound();

    if (string.IsNullOrWhiteSpace(request.Title))
        return Results.BadRequest(new { error = "Title is required." });

    task.Title = request.Title.Trim();
    task.Description = request.Description?.Trim() ?? "";
    task.IsCompleted = request.IsCompleted;

    await db.SaveChangesAsync();
    return Results.Ok(task);
});

app.MapDelete("/api/tasks/{id:int}", async (int id, TaskDbContext db) =>
{
    var task = await db.Tasks.FindAsync(id);
    if (task is null)
        return Results.NotFound();

    db.Tasks.Remove(task);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();

public record CreateTaskRequest(string Title, string? Description);
public record UpdateTaskRequest(string Title, string? Description, bool IsCompleted);
