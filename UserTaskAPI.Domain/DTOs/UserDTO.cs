namespace UserTask.Domain.DTOs;

public record UserDTO(
    int Id,
    string Username,
    string Email,
    string FirstName,
    string LastName,
    string Role,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt

);