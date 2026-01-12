using UserTask.Domain.Enums;

namespace UserTask.Domain.Models;

public record CreateTaskModel(
    string Title,
    string Description,
    TaskState Status,
    string Priority,
    int? AssignedToUserId,
    DateTime? DueDate
);