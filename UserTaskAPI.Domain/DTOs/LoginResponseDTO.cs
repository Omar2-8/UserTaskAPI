namespace UserTask.Domain.DTOs;

public record LoginResponseDTO(
    string Token,
    string Username,
    string Role
); 