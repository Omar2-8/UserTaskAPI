using UserTask.Domain.DTOs;
using UserTask.Domain.Models;

namespace UserTask.Application.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDTO> LoginAsync(LoginRequestModel model);
}