using System.Linq.Expressions;

namespace CatTask.Domain.IRepository;
public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T?> GetByAsync(Expression<Func<T,bool>>predicate);
    Task<T> AddAsync(T entity);
    Task DeleteAsync(int id);
}
