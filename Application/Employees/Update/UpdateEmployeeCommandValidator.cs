using FluentValidation;

namespace Application.Employees.Update
{
    public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidator()
        {
            RuleFor(r => r.EmployeeId).NotEmpty();
            RuleFor(r => r.FullName).NotEmpty();
            RuleFor(r => r.Salary).NotEmpty();
        }
    }
}
