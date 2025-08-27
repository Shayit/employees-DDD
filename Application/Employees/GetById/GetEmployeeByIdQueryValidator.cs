using FluentValidation;

namespace Application.Employees.GetById
{
    public class GetEmployeeByIdQueryValidator : AbstractValidator<GetEmployeeByIdQuery>
    {
        public GetEmployeeByIdQueryValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty();
        }
    }
}
