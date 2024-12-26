using CatTask.Domain.Abstractions;
using CatTask.Domain.DTO.TODos;
using FluentValidation;

namespace CatTask.Domain.FluentValidations.ToDoValidations;
public class ToDoRequestValidator:AbstractValidator<ToDoRequest>
{
    public ToDoRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required");

        RuleFor(x => x.Status)
            .Must(ValidStatus)
            .WithMessage($"{nameof(ToDoRequest.Status)} is invalid it should be {ConstValues.pending} or {ConstValues.completed}");
    }
    private bool ValidStatus(string status)
    {
        return string.Equals(status, ConstValues.pending,StringComparison.OrdinalIgnoreCase) ||
               string.Equals(status, ConstValues.completed, StringComparison.OrdinalIgnoreCase);
    }
}
