using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using UserTask.Domain.DTOs;
using UserTask.Domain.Models;
using UserTask.Tests.Infrastructure;
using Xunit;

namespace UserTask.Tests;

public sealed class TasksControllerTests(TestWebAppFactory factory)
        : ApiTestBase(factory)
{
    [Fact]
    public async Task Admin_Can_Get_All_Tasks()
    {
        await AuthenticateAsAdmin();

        var response = await Client.GetAsync("/api/tasks");

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var tasks = await response.Content.ReadFromJsonAsync<List<TaskDTO>>();
        tasks.Should().NotBeEmpty();
    } 

    [Fact]
    public async Task Admin_Can_Create_Task()
    {
        await AuthenticateAsAdmin();

        var model = new CreateTaskModel
        (
            Title : "Test Task",
            Description : "Test Desc",
            Priority : Domain.Enums.PriorityLevel.High.ToString(), 
            Status : Domain.Enums.TaskState.Pending, 
            AssignedToUserId : 1,
            DueDate : DateTime.UtcNow.AddDays(7)

        );

        var response = await Client.PostAsJsonAsync("/api/tasks", model);

        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}