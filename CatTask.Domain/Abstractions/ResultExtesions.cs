using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatTask.Domain.Abstractions;
public static class ResultExtesions
{
    public static ObjectResult ToProblem(this Error error)
    {
        var problem = Results.Problem(statusCode: error.StatusCode);
        var problemDetails = problem.GetType().GetProperty(nameof(ProblemDetails))!.GetValue(problem) as ProblemDetails;
        problemDetails!.Extensions = new Dictionary<string, object?>
            {
                {"errors",new[]{error} }
            };
        return new ObjectResult(problemDetails);
    }
}
