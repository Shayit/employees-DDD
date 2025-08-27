using ErrorOr;
using MediatR;

namespace Application.Employees.Delete
{
    public record DeleteEmployeeCommand(string Id) : IRequest<ErrorOr<Unit>>;
}
