using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace UserTask.Tests;

public static class TestTokens
{
    public static async Task<string> GetAdminToken(HttpClient client)
        => await Login(client, "admin", "demo");

    public static async Task<string> GetUserToken(HttpClient client)
        => await Login(client, "user", "demo");

    private static async Task<string> Login(HttpClient client, string username, string password)
    {
        var response = await client.PostAsJsonAsync("/api/auth/login", new
        {
            username,
            password
        });

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadFromJsonAsync<AuthResponse>();
        return json!.Token;
    }

    private sealed class AuthResponse
    {
        public string Token { get; set; } = default!;
    }
}
