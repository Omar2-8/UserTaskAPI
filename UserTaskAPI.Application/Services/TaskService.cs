using UserTask.Application.Interfaces;
using UserTask.Domain.DTOs;
using UserTask.Domain.Mapper;
using UserTask.Domain.Models;

namespace UserTask.Application.Services;

public sealed class TaskService(ITaskRepository taskRepo, IUnitOfWork uow) : ITaskService
{
    public async Task<TaskDTO> GetByIdAsync(int id, int currentUserId, bool isAdmin)
    {
        var task = await taskRepo.GetByIdAsync(id) ?? throw new KeyNotFoundException("Task not found");
       
        if (!isAdmin && task.AssignedToUserId != currentUserId)
            throw new KeyNotFoundException("Task not found");

        return task.ToDTO();
    }

    public async Task<List< TaskDTO>> GetAllAsync(int currentUserId, bool isAdmin)
    { 
        var tasks = await taskRepo.GetAllAsync();

        if(!isAdmin) 
            tasks = [.. tasks.Where(t => t.AssignedToUserId == currentUserId)];
        
        return [.. tasks.Select(x => x.ToDTO())];
    }

    public async Task<TaskDTO> CreateAsync(CreateTaskModel model, int currentUserId, bool isAdmin)
    {
        if (!isAdmin) throw new UnauthorizedAccessException("Only admins can create tasks");

        var task = model.ToEntity();

        await taskRepo.AddAsync(task);
        await uow.SaveChangesAsync();
        return task.ToDTO();
    }

    public async Task<TaskDTO> UpdateAsync(int id, UpdateTaskModel model, int currentUserId, bool isAdmin)
    {
        var task = await taskRepo.GetByIdAsync(id) ?? throw new KeyNotFoundException("Task not found");

        if (!isAdmin && task.AssignedToUserId != currentUserId)
            throw new UnauthorizedAccessException("Cannot update task not assigned to you");

        if (isAdmin || task.AssignedToUserId == currentUserId)
            model.ToUpdateEntity(task, isAdmin);
        

        await uow.SaveChangesAsync();
        return task.ToDTO();
    }

    public async Task DeleteAsync(int id, bool isAdmin)
    {
        if (!isAdmin) throw new UnauthorizedAccessException("Only admins can delete tasks");

        var task = await taskRepo.GetByIdAsync(id) ?? throw new KeyNotFoundException("Task not found");
        taskRepo.Remove(task);
        await uow.SaveChangesAsync();
    }
}