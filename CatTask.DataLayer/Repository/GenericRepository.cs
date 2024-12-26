using System.Linq.Expressions;
using CatTask.DataLayer.Data;
using CatTask.Domain.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CatTask.DataLayer.Repository;
public class GenericRepository<T>(ApplicationDbContext context) : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context = context;
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _dbSet.ToListAsync();

    public async Task<T?> GetByAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(predicate);
        return entity!;
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity!;
    }
    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity,cancellationToken);
        return entity;  
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        // suppuse that entity is not null
        _dbSet.Remove(entity!);
    }

    
}
