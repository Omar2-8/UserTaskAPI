using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using UserTask.Domain.Entities;
using UserTask.Domain.Interfaces;

namespace UserTask.Infrastructure.Auth.JWT;

public sealed class JwtTokenGenerator(IOptions<JwtOptions> options) : ITokenService
{ 
    public string GenerateToken(User user)
    {
        var claims = JwtClaimsFactory.Create(user);

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(options.Value.SecretKey));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: options.Value.Issuer,
            audience: options.Value.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(options.Value.ExpiresInMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}