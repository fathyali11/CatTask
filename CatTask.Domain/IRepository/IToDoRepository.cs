using CatTask.Domain.DTO.TODos;
using CatTask.Domain.Entities;

namespace CatTask.Domain.IRepository;
public interface IToDoRepository:IGenericRepository<ToDo>
{
    Task<ToDo?> UpdateAsync(int id, ToDoRequest request);
}
