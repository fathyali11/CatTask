using AutoMapper;
using CatTask.DataLayer.Data;
using CatTask.DataLayer.Repository;
using CatTask.Domain.Abstractions;
using CatTask.Domain.DTO.TODos;
using CatTask.Domain.Entities;
using CatTask.Domain.IRepository;
using OneOf;

namespace CatTask.Services.Services;
public class ToDoServices(IUnitOfWork unitOfWork,ApplicationDbContext contex,IMapper mapper):ToDoRepository(contex,mapper),IToDoServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<OneOf<IEnumerable<ToDoResponse>, Error>> GetAllToDosAsync(CancellationToken cancellationToken = default)
    {
        var todos = await _unitOfWork.ToDoRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<ToDoResponse>>(todos);
    }
    public async Task<OneOf<ToDoResponse, Error>> GetToDosAsync(int id, CancellationToken cancellationToken = default)
    {
        var todo = await _unitOfWork.ToDoRepository.GetByIdAsync(id);
        if (todo is null)
            return TodoErrors.NotFound;
        return _mapper.Map<ToDoResponse>(todo);
    }
    public async Task<OneOf<ToDoResponse, Error>> AddToDosAsync(ToDoRequest request, CancellationToken cancellationToken = default)
    {
        var todo = _mapper.Map<ToDo>(request);
        var result=await _unitOfWork.ToDoRepository.AddAsync(todo, cancellationToken);
        await _unitOfWork.SaveChanges(cancellationToken);   
        var response = _mapper.Map<ToDoResponse>(result);
        return response;
    }
    public async Task<OneOf<ToDoResponse, Error>> UpdateToDosAsync(int id, ToDoRequest request, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return TodoErrors.NotFound;
        var todoFromDb=await _unitOfWork.ToDoRepository.GetByIdAsync(id);
        if (todoFromDb == null)
            throw new Exception("ToDo not found");
        var todo = _mapper.Map(request, todoFromDb);
        await _unitOfWork.SaveChanges(cancellationToken);
        var response = _mapper.Map<ToDoResponse>(todo);
        return response;    
    }
    public async Task<OneOf<bool, Error>> DeleteToDosAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return TodoErrors.NotFound;
        await _unitOfWork.ToDoRepository.DeleteAsync(id);
        await _unitOfWork.SaveChanges(cancellationToken);
        return true;
    }
}
