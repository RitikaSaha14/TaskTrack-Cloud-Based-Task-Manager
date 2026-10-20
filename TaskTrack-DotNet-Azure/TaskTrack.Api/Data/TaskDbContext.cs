using Microsoft.EntityFrameworkCore;
using TaskTrack.Api.Models;

namespace TaskTrack.Api.Data;

public class TaskDbContext(DbContextOptions<TaskDbContext> options) : DbContext(options)
{
    public DbSet<TaskItem> Tasks => Set<TaskItem>();
}
