namespace UserTask.Domain.Models;

public record CreateUserModel(
    string Username,
    string Email,
    string Password,
    string FirstName,
    string LastName,
    string Role
);