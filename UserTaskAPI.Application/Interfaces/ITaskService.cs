using UserTask.Domain.DTOs;
using UserTask.Domain.Models;

namespace UserTask.Application.Interfaces;

public interface ITaskService
{
    Task<TaskDTO> GetByIdAsync(int id, int currentUserId, bool isAdmin);
    Task<List<TaskDTO>> GetAllAsync(int currentUserId, bool isAdmin);
    Task<TaskDTO> CreateAsync(CreateTaskModel model, int currentUserId, bool isAdmin);
    Task<TaskDTO> UpdateAsync(int id, UpdateTaskModel model, int currentUserId, bool isAdmin);
    Task DeleteAsync(int id, bool isAdmin);
}