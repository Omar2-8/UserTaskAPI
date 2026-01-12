using UserTask.Domain.Enums;

namespace UserTask.Domain.Entities;

public class User : BaseEntity
{ 
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public required string FirstName { get; set; } 
    public required string LastName { get; set; } 
    public UserRole Role { get; set; } = UserRole.User; 
    public bool IsActive { get; set; } = true; 
    public virtual List<TaskItem> AssignedTasks { get; set; } = [];
}