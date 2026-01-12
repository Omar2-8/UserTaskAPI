using UserTask.Domain.DTOs;
using UserTask.Domain.Entities;
using UserTask.Domain.Enums;
using UserTask.Domain.Models;

namespace UserTask.Domain.Mapper;

public static class TaskMapper
{
    public static TaskDTO ToDTO(this TaskItem task) =>
    new(
        task.Id,
        task.Title,
        task.Description,
        task.Status,
        task.Priority.ToString(),
        task.AssignedToUserId,
        task.AssignedToUser?.Username,
        task.DueDate,
        task.CompletedAt,
        task.CreatedAt,
        task.UpdatedAt
    );


    public static TaskItem ToEntity(this CreateTaskModel model) =>
    new()
    {
        Title = model.Title,
        Description = model.Description,
        Status = model.Status,
        Priority = Enum.Parse<PriorityLevel>(model.Priority, true),
        AssignedToUserId = model.AssignedToUserId,
        DueDate = model.DueDate,
        CreatedAt = DateTime.UtcNow,
    };


    public static TaskItem ToUpdateEntity(this UpdateTaskModel model, TaskItem task, bool isAdmin)
    {

        task.UpdatedAt = DateTime.UtcNow;

        if (!isAdmin)
        {
            if (model.Status.HasValue)
                task.Status = model.Status.Value;

            return task;
        }

        if (!string.IsNullOrWhiteSpace(model.Title))
            task.Title = model.Title;

        if (!string.IsNullOrWhiteSpace(model.Description))
            task.Description = model.Description;


        if (!string.IsNullOrWhiteSpace(model.Priority))
            task.Priority = Enum.Parse<PriorityLevel>(model.Priority, true);

        if (model.AssignedToUserId.HasValue)
            task.AssignedToUserId = model.AssignedToUserId;

        if (model.DueDate.HasValue)
            task.DueDate = model.DueDate;

        if (model.CompletedAt.HasValue)
            task.CompletedAt = model.CompletedAt;

        return task;
    }

}