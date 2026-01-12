using UserTask.Domain.Entities;
using UserTask.Domain.Enums;

namespace UserTask.Infrastructure.Data;

public static class DbSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (context.Users.Any())
            return;

        var admin = new User
        {
            Username = "admin",
            Email = "admin@test.com",
            PasswordHash = "demo",
            FirstName = "System",
            LastName = "Admin",
            Role = UserRole.Admin,
            IsActive = true
        };

        var user = new User
        {
            Username = "user",
            Email = "user@test.com",
            PasswordHash = "demo",
            FirstName = "Normal",
            LastName = "User",
            Role = UserRole.User,
            IsActive = true
        };

        context.Users.AddRange(admin, user);
        context.SaveChanges();

        context.Tasks.AddRange(
            new TaskItem
            {
                Title = "Admin Task",
                Description = "Admin owned task",
                AssignedToUserId = admin.Id
            },
            new TaskItem
            {
                Title = "User Task 1",
                Description = "Assigned to user",
                AssignedToUserId = user.Id
            },
            new TaskItem
            {
                Title = "User Task 2",
                Description = "Second user task",
                AssignedToUserId = user.Id
            }
        );

        context.SaveChanges();
    }
}