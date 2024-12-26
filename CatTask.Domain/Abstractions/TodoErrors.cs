using Microsoft.AspNetCore.Http;

namespace CatTask.Domain.Abstractions;
public static class TodoErrors
{
    public readonly static Error NotFound = new("TODO.NOTFOUND", "Todo not found", StatusCodes.Status404NotFound);
}
