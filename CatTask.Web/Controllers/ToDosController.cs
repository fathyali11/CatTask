using CatTask.Domain.Abstractions;
using CatTask.Domain.DTO.TODos;
using CatTask.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneOf.Types;

namespace CatTask.Web.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ToDosController(IToDoServices toDoServices) : ControllerBase
{
    private readonly IToDoServices _toDoServices = toDoServices;

    [HttpGet("")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        var result = await _toDoServices.GetAllToDosAsync(cancellationToken);
        return result.Match<IActionResult>(
            response=>Ok(response),
            error=>error.ToProblem()
            );
    }
    [HttpPost("")]
    public async Task<IActionResult> Add([FromBody] ToDoRequest request,CancellationToken cancellationToken = default)
    {
        var result = await _toDoServices.AddToDosAsync(request,cancellationToken);
        return result.Match<IActionResult>(
            response=>CreatedAtAction(nameof(Get), new { id = response.Id }, response),
            error=>error.ToProblem()
            );
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id,CancellationToken cancellationToken = default)
    {
        var result = await _toDoServices.GetToDosAsync(id,cancellationToken);
        return result.Match<IActionResult>(
            response=>Ok(result),
            error => error.ToProblem()
            );
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute]int id,[FromBody]ToDoRequest request,CancellationToken cancellationToken = default)
    {
        var result = await _toDoServices.UpdateToDosAsync(id,request,cancellationToken);
        return result.Match<IActionResult>(
            response => Ok(result),
            error => error.ToProblem()
            );
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken = default)
    {
        var result = await _toDoServices.DeleteToDosAsync(id,cancellationToken);
        return result.Match<IActionResult>(
            response => NoContent(),
            error => error.ToProblem()
            );
    }
}
