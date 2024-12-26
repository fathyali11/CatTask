using AutoMapper;
using CatTask.DataLayer.Data;
using CatTask.Domain.IRepository;

namespace CatTask.DataLayer.Repository;
public class UnitOfWork(ApplicationDbContext context,IMapper mapper) : IUnitOfWork
{
    private readonly ApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;
    private readonly IToDoRepository ?_toDoRepository;
    public IToDoRepository ToDoRepository =>
        _toDoRepository ?? new ToDoRepository(_context,_mapper);

    public async Task SaveChanges(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
