using FluentValidation;

namespace Application.Employees.Create
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(r => r.EmployeeId).NotEmpty();
            RuleFor(r => r.FullName).NotEmpty();
            RuleFor(r => r.Salary).NotEmpty();
        }

    }
}
