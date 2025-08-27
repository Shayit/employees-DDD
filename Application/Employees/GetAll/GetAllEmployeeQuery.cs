using Application.Employees.Common;
using ErrorOr;
using MediatR;

namespace Application.Employees.GetAll
{
    public record GetAllEmployeeQuery() : IRequest<ErrorOr<IReadOnlyList<EmployeeResponse>>>;
}
