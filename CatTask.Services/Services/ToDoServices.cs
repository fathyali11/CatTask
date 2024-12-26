using AutoMapper;
using CatTask.DataLayer.Data;
using CatTask.DataLayer.Repository;
using CatTask.Domain.DTO.TODos;
using CatTask.Domain.Entities;
using CatTask.Domain.IRepository;

namespace CatTask.Services.Services;
public class ToDoServices(IUnitOfWork unitOfWork,ApplicationDbContext contex,IMapper mapper):ToDoRepository(contex,mapper),IToDoServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<ToDoResponse>> GetAllToDosAsync(CancellationToken cancellationToken = default)
    {
        var todos = await _unitOfWork.ToDoRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<ToDoResponse>>(todos);
    }
    public async Task<ToDoResponse> GetToDosAsync(int id, CancellationToken cancellationToken = default)
    {
        var todo = await _unitOfWork.ToDoRepository.GetByIdAsync(id);
        return _mapper.Map<ToDoResponse>(todo);
    }
    public async Task<ToDoResponse> AddToDosAsync(ToDoRequest request, CancellationToken cancellationToken = default)
    {
        var todo = _mapper.Map<ToDo>(request);
        var result=await _unitOfWork.ToDoRepository.AddAsync(todo, cancellationToken);
        await _unitOfWork.SaveChanges(cancellationToken);   
        var response = _mapper.Map<ToDoResponse>(result);
        return response;
    }
    public async Task<ToDoResponse> UpdateToDosAsync(int id, ToDoRequest request, CancellationToken cancellationToken = default)
    {
        if(id <= 0)
            throw new Exception("Id must be greater than 0");
        var todoFromDb=await _unitOfWork.ToDoRepository.GetByIdAsync(id);
        if (todoFromDb == null)
            throw new Exception("ToDo not found");
        var todo = _mapper.Map(request, todoFromDb);
        await _unitOfWork.SaveChanges(cancellationToken);
        var response = _mapper.Map<ToDoResponse>(todo);
        return response;    
    }
    public async Task<bool> DeleteToDosAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return false;
        await _unitOfWork.ToDoRepository.DeleteAsync(id);
        await _unitOfWork.SaveChanges(cancellationToken);
        return true;
    }
}
