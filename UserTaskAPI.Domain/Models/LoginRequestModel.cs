namespace UserTask.Domain.Models;

public record LoginRequestModel(
    string Username,
    string Password
);