using Microsoft.EntityFrameworkCore;
using UserTask.Application.Interfaces;
using UserTask.Domain.Entities;
using UserTask.Infrastructure.Data;

namespace UserTask.Infrastructure.Repositories;

public sealed class UserRepository(AppDbContext context) : IUserRepository
{ 
    public Task<List<User>> GetAllAsync()
        => context.Users.ToListAsync();

    public Task AddAsync(User user)
        => context.Users.AddAsync(user).AsTask();

    public void Remove(User user)
        => context.Users.Remove(user);

    public Task<User?> GetByIdAsync(int id)
    => context.Users.FindAsync(id).AsTask();

    public Task<User?> GetByUsernameAsync(string username)
    => context.Users
        .FirstOrDefaultAsync(x => x.Username == username);
}