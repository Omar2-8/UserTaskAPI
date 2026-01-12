using Microsoft.EntityFrameworkCore;
using UserTask.Application.Interfaces;
using UserTask.Domain.Entities;
using UserTask.Infrastructure.Data;

namespace UserTask.Infrastructure.Repositories;

public sealed class TaskRepository(AppDbContext context) : ITaskRepository
{
    public Task<TaskItem?> GetByIdAsync(int id)
        => context.Tasks
            .Include(t => t.AssignedToUser)
            .FirstOrDefaultAsync(t => t.Id == id);

    public Task<List<TaskItem>> GetAllAsync()
        => context.Tasks
            .Include(t => t.AssignedToUser)
            .ToListAsync();

    public Task AddAsync(TaskItem task)
        => context.Tasks.AddAsync(task).AsTask();

    public void Remove(TaskItem task)
        => context.Tasks.Remove(task);
}