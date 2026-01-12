using Microsoft.AspNetCore.Mvc;
using UserTask.Application.Interfaces;
using UserTask.Domain.DTOs;
using UserTask.Domain.Models;

namespace UserTask.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : Controller
{
 
    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseDTO>> Login(LoginRequestModel model)
    {
        try
        {
            var dto = await authService.LoginAsync(model);
            return Ok(dto);
        }
        catch (UnauthorizedAccessException)
        {
            return Unauthorized("Invalid username or password");
        }
    }
}