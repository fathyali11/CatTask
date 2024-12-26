using CatTask.Domain.DTO.TODos;
using CatTask.Domain.IRepository;

namespace CatTask.Services.Services;
public interface IToDoServices:IToDoRepository
{
    Task<IEnumerable<ToDoResponse>> GetAllToDosAsync(CancellationToken cancellationToken = default);
    Task<ToDoResponse> GetToDosAsync(int id, CancellationToken cancellationToken = default);
    Task<ToDoResponse> AddToDosAsync(ToDoRequest request, CancellationToken cancellationToken = default);
    Task<ToDoResponse> UpdateToDosAsync(int id, ToDoRequest request, CancellationToken cancellationToken = default);
}
