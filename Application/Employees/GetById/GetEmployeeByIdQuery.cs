using Application.Employees.Common;
using ErrorOr;
using MediatR;

namespace Application.Employees.GetById
{
    public record GetEmployeeByIdQuery(string Id) : IRequest<ErrorOr<EmployeeResponse>>;
}
