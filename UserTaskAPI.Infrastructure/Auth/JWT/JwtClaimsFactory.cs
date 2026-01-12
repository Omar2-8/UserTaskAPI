using System.Security.Claims;
using UserTask.Domain.Entities;

namespace UserTask.Infrastructure.Auth.JWT;

public static class JwtClaimsFactory
{
    public static IEnumerable<Claim> Create(User user)
    {
        if (!user.IsActive)
            throw new InvalidOperationException("Inactive user cannot generate token");

        return
            [
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            ];
    }
}