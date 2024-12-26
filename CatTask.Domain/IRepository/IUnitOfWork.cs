namespace CatTask.Domain.IRepository;
public interface IUnitOfWork
{
    IToDoRepository ToDoRepository { get; }

    Task SaveChanges(CancellationToken cancellationToken = default);
}
