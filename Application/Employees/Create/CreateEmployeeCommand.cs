using ErrorOr;
using MediatR;

namespace Application.Employees.Create
{
    public record CreateEmployeeCommand(
        string EmployeeId,
        string FullName,
        float Salary,
        bool Active) : IRequest<ErrorOr<Unit>>;
}
