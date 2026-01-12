using UserTask.Domain.Entities;

namespace UserTask.Application.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetByUsernameAsync(string username);
    Task<List<User>> GetAllAsync();
    Task AddAsync(User user);
    void Remove(User user);
}