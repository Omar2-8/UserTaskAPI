using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserTask.Application.Interfaces;
using UserTask.Domain.DTOs;
using UserTask.Domain.Models;

namespace UserTask.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TasksController(ITaskService taskService) : ControllerBase
{
    private int CurrentUserId => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
    private bool IsAdmin => User.IsInRole("Admin");

    [HttpGet]
    public async Task<ActionResult<List<TaskDTO>>> GetAll()
    {
        return Ok(await taskService.GetAllAsync(CurrentUserId , IsAdmin));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TaskDTO>> GetById(int id) => Ok(await taskService.GetByIdAsync(id, CurrentUserId, IsAdmin));

    [HttpPost]
    public async Task<ActionResult<TaskDTO>> Create(CreateTaskModel model)
    {
        var task = await taskService.CreateAsync(model, CurrentUserId, IsAdmin);
        return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TaskDTO>> Update(int id, UpdateTaskModel model)
    {
        var task = await taskService.UpdateAsync(id, model, CurrentUserId, IsAdmin);
        return Ok(task);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await taskService.DeleteAsync(id, IsAdmin);
        return NoContent();
    }
}