using UserTask.Application.Interfaces;
using UserTask.Domain.DTOs;
using UserTask.Domain.Mapper;
using UserTask.Domain.Models;

namespace UserTask.Application.Services;

public sealed class UserService(IUserRepository userRepo, IUnitOfWork uow) : IUserService
{
    public async Task<UserDTO> GetByIdAsync(int id)
    {
        var user = await userRepo.GetByIdAsync(id) ?? throw new KeyNotFoundException("User not found");
        return user.ToDTO();
    }

    public async Task<List<UserDTO>> GetAllAsync()
    {
        var users = await userRepo.GetAllAsync();
        return [.. users.Select(x=>x.ToDTO())];
    }

    public async Task<UserDTO> CreateAsync(CreateUserModel model)
    {
        var user = model.ToEntity();

        await userRepo.AddAsync(user);
        await uow.SaveChangesAsync();

        return user.ToDTO();
    }

    public async Task<UserDTO> UpdateAsync(int id, UpdateUserModel model)
    {
        var user = await userRepo.GetByIdAsync(id) ?? throw new KeyNotFoundException("User not found");
        user = model.ToUpdateEntity(user);

        await uow.SaveChangesAsync();
        return user.ToDTO();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await userRepo.GetByIdAsync(id) ?? throw new KeyNotFoundException("User not found");
        userRepo.Remove(user);
        await uow.SaveChangesAsync();
    }
}