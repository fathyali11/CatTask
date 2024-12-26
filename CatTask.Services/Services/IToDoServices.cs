using CatTask.Domain.Abstractions;
using CatTask.Domain.DTO.TODos;
using CatTask.Domain.IRepository;
using OneOf;

namespace CatTask.Services.Services;
public interface IToDoServices:IToDoRepository
{
    Task<OneOf<IEnumerable<ToDoResponse>,Error>> GetAllToDosAsync(CancellationToken cancellationToken = default);
    Task<OneOf<ToDoResponse,Error>> GetToDosAsync(int id, CancellationToken cancellationToken = default);
    Task<OneOf<ToDoResponse, Error>> AddToDosAsync(ToDoRequest request, CancellationToken cancellationToken = default);
    Task<OneOf<ToDoResponse, Error>> UpdateToDosAsync(int id, ToDoRequest request, CancellationToken cancellationToken = default);
    Task<OneOf<bool, Error>> DeleteToDosAsync(int id, CancellationToken cancellationToken = default);
}
