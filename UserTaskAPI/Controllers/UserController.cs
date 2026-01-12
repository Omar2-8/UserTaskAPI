using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserTask.Application.Interfaces;
using UserTask.Domain.DTOs;
using UserTask.Domain.Models;

namespace UserTask.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<UserDTO>>> GetAll() => Ok(await userService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDTO>> GetById(int id) => Ok(await userService.GetByIdAsync(id));

    [HttpPost]
    public async Task<ActionResult<UserDTO>> Create(CreateUserModel model)
    {
        var user = await userService.CreateAsync(model);
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserDTO>> Update(int id, UpdateUserModel model)
    {
        var updated = await userService.UpdateAsync(id, model);
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await userService.DeleteAsync(id);
        return NoContent();
    }
}