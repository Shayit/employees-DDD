using ErrorOr;
using MediatR;

namespace Application.Employees.Update
{
    public record UpdateEmployeeCommand(
        string EmployeeId,
        string FullName,
        float Salary,
        bool Active) : IRequest<ErrorOr<Unit>>;
}
