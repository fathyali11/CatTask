using CatTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatTask.DataLayer.Data;
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<ToDo> ToDos { get; set; } = default!;
}
