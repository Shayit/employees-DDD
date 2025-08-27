using Application.Employees.Common;
using Domain.Employees;
using ErrorOr;
using MediatR;

namespace Application.Employees.GetAll
{
    internal sealed class GetAllEmployeeQueryHandler(IEmployeeRepository employeeRepository) : IRequestHandler<GetAllEmployeeQuery, ErrorOr<IReadOnlyList<EmployeeResponse>>>
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));

        public async Task<ErrorOr<IReadOnlyList<EmployeeResponse>>> Handle(GetAllEmployeeQuery query, CancellationToken cancellationToken)
        {
            IReadOnlyList<Employee> employees = await _employeeRepository.GetAll();

            return employees.Select(employee => new EmployeeResponse(
                employee.EmployeeId,
                employee.FullName,
                employee.Salary,
                employee.Active)).ToList();
        }
    }
}