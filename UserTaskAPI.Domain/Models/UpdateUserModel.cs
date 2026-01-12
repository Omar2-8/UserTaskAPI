namespace UserTask.Domain.Models;

public record UpdateUserModel(
    string? FirstName = null,
    string? LastName = null,
    string? Password = null,
    bool? IsActive = null,
    string? Role = null
);