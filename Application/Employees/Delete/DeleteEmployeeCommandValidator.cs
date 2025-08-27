using FluentValidation;

namespace Application.Employees.Delete
{
    public class DeleteCashHeadCommandValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteCashHeadCommandValidator()
        {
            RuleFor(r => r.Id)
            .NotEmpty();
        }
    }
}
