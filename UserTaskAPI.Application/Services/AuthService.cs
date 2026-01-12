using UserTask.Application.Interfaces;
using UserTask.Domain.DTOs;
using UserTask.Domain.Interfaces;
using UserTask.Domain.Models;

namespace UserTask.Application.Services;

public class AuthService(IUserRepository userRepo, ITokenService tokenService) : IAuthService
{
    public async Task<LoginResponseDTO> LoginAsync(LoginRequestModel dto)
    {
        var user = await userRepo.GetByUsernameAsync(dto.Username);
        if (user == null || user.PasswordHash != dto.Password)
            throw new UnauthorizedAccessException();

        var token = tokenService.GenerateToken(user);

        return new LoginResponseDTO(token, user.Username, user.Role.ToString());
    }
}