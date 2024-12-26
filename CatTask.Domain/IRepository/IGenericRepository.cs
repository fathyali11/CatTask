using System.Linq.Expressions;

namespace CatTask.Domain.IRepository;
public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<T?> GetByIdAsync(int id);
    Task<T?> GetByAsync(Expression<Func<T,bool>>predicate, CancellationToken cancellationToken = default);
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id);
}
