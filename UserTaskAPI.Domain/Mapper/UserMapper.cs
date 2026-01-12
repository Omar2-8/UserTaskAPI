using UserTask.Domain.DTOs;
using UserTask.Domain.Entities;
using UserTask.Domain.Enums;
using UserTask.Domain.Models;

namespace UserTask.Domain.Mapper;

public static class UserMapper
{

    public static UserDTO ToDTO(this User user) =>
      new(
          user.Id,
          user.Username,
          user.Email,
          user.FirstName,
          user.LastName,
          user.Role.ToString(),
          user.IsActive
      );

    public static User ToEntity(this CreateUserModel model) =>
    new()
    {
        Username = model.Username,
        Email = model.Email,
        PasswordHash = model.Password, // Password hashing should be applied in real scenario
        FirstName = model.FirstName,
        LastName = model.LastName,
        Role = Enum.Parse<UserRole>(model.Role, true),
        IsActive = true
    };


    public static User ToUpdateEntity(this UpdateUserModel model, User user)
    { 
        if (!string.IsNullOrWhiteSpace(model.FirstName))
            user.FirstName = model.FirstName;

        if (!string.IsNullOrWhiteSpace(model.LastName))
            user.LastName = model.LastName;

        if (!string.IsNullOrWhiteSpace(model.Password))
            user.PasswordHash = model.Password;

        if (!string.IsNullOrWhiteSpace(model.Role)) 
            user.Role = Enum.Parse<UserRole>(model.Role, true);

        if (model.IsActive.HasValue) 
            user.IsActive = model.IsActive.Value;


        return user;
    }
}
