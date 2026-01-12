using UserTask.Domain.Entities;

namespace UserTask.Application.Interfaces;

public interface ITaskRepository
{
    Task<TaskItem?> GetByIdAsync(int id);
    Task<List<TaskItem>> GetAllAsync();
    Task AddAsync(TaskItem task);
    void Remove(TaskItem task);
}