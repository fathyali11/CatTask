using CatTask.Domain.Abstractions;

namespace CatTask.Domain.Entities;
public class ToDo
{
    public int Id { get; set; }
    public string Title { get; set; }=string.Empty;
    public string Status { get; set; } = ConstValues.pending;
}
