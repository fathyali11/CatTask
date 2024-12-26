using AutoMapper;
using CatTask.DataLayer.Data;
using CatTask.Domain.DTO.TODos;
using CatTask.Domain.Entities;
using CatTask.Domain.IRepository;

namespace CatTask.DataLayer.Repository;
public class ToDoRepository(ApplicationDbContext context,IMapper mapper):GenericRepository<ToDo>(context),IToDoRepository
{
    private readonly IMapper _mapper = mapper;
    public async Task<ToDo?> UpdateAsync(int id, ToDoRequest request)
    {
        var todo = await GetByIdAsync(id);
        if (todo == null)
            return null;
        _mapper.Map(request, todo);
        return todo!;
    }
}
