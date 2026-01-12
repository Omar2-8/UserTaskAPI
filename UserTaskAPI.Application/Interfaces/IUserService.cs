using UserTask.Domain.DTOs;
using UserTask.Domain.Models;

namespace UserTask.Application.Interfaces;

public interface IUserService
{
    Task<UserDTO> GetByIdAsync(int id);
    Task<List<UserDTO>> GetAllAsync();
    Task<UserDTO> CreateAsync(CreateUserModel  dto);
    Task<UserDTO> UpdateAsync(int id, UpdateUserModel dto);
    Task DeleteAsync(int id);
}