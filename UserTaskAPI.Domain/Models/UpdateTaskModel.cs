using UserTask.Domain.Enums;

namespace UserTask.Domain.Models;

public record UpdateTaskModel(
    string? Title = null,
    string? Description = null,
    TaskState? Status = null,
    string? Priority = null,
    int? AssignedToUserId = null,
    DateTime? DueDate = null,
    DateTime? CompletedAt = null
);