using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using UserTask.Domain.DTOs;
using UserTask.Domain.Enums;
using UserTask.Domain.Models;
using UserTask.Tests.Infrastructure;
using Xunit;

namespace UserTask.Tests;

public sealed class UsersControllerTests(TestWebAppFactory factory)
        : ApiTestBase(factory)
{
    [Fact]
    public async Task GetAll_ShouldReturnUsers_ForAdmin()
    {
        await AuthenticateAsAdmin();
        var response = await Client.GetAsync("/api/users");

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var users = await response.Content.ReadFromJsonAsync<List<UserDTO>>();
        users.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Create_ShouldCreateUser()
    {
        var model = new CreateUserModel
        (
            Username : "newuser",
            Email : "new@test.com",
            Password : "123456",
            FirstName : "New",
            LastName : "User",
            Role : UserRole.User.ToString()
        );
        await AuthenticateAsAdmin();
        var response = await Client.PostAsJsonAsync("/api/users", model);

        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}