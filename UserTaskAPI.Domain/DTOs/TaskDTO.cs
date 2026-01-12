using UserTask.Domain.Enums;

namespace UserTask.Domain.DTOs;

public record TaskDTO(
    int Id,
    string Title,
    string Description,
    TaskState Status,
    string Priority,
    int? AssignedToUserId,
    string? AssignedToUsername,
    DateTime? DueDate,
    DateTime? CompletedAt,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);