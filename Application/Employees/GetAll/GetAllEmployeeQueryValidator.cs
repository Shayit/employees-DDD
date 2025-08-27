using FluentValidation;

namespace Application.Employees.GetAll
{
    public class GetAllEmployeeQueryValidator : AbstractValidator<GetAllEmployeeQuery>
    {
        public GetAllEmployeeQueryValidator()
        {
            RuleFor(r => r.ToString()).NotEmpty();
        }
    }
}
