
using UserTask.Domain.Enums;

namespace UserTask.Domain.Entities;

public class TaskItem : BaseEntity
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public TaskState Status { get; set; } = TaskState.Pending;
    public PriorityLevel Priority { get; set; } = PriorityLevel.Medium;
    public DateTime? DueDate { get; set; }
    public DateTime? CompletedAt { get; set; }

    public int? AssignedToUserId { get; set; }
    public virtual User? AssignedToUser { get; set; }
}
