namespace UserTask.Infrastructure.Auth.JWT;

public sealed class JwtOptions
{
    public string Issuer { get; init; } = string.Empty;
    public string Audience { get; init; } = string.Empty;
    public string SecretKey { get; init; } = string.Empty;  
    public int ExpiresInMinutes { get; set; } = 60;
}