using CatTask.Domain.DTO.TODos;
using CatTask.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatTask.Web.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ToDosController(IToDoServices toDoServices) : ControllerBase
{
    private readonly IToDoServices _toDoServices = toDoServices;

    [HttpGet("")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        var todos = await _toDoServices.GetAllToDosAsync(cancellationToken);
        return Ok(todos);
    }
    [HttpPost("")]
    public async Task<IActionResult> Add([FromBody] ToDoRequest request,CancellationToken cancellationToken = default)
    {
        var todos = await _toDoServices.AddToDosAsync(request,cancellationToken);
        return CreatedAtAction(nameof(Get), new { id = todos.Id }, todos);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id,CancellationToken cancellationToken = default)
    {
        var response = await _toDoServices.GetToDosAsync(id,cancellationToken);
        return Ok(response);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute]int id,[FromBody]ToDoRequest request,CancellationToken cancellationToken = default)
    {
        var response = await _toDoServices.UpdateToDosAsync(id,request,cancellationToken);
        return Ok(response);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken = default)
    {
        var result = await _toDoServices.DeleteToDosAsync(id,cancellationToken);
        return result ? NoContent() : NotFound();
    }
}
