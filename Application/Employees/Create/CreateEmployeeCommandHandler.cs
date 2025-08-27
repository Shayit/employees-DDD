using Domain.Employees;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Employees.Create
{
    internal sealed class CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateEmployeeCommand, ErrorOr<Unit>>
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        public async Task<ErrorOr<Unit>> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
        {

            var employee = new Employee(
                command.EmployeeId,
                command.FullName,
                command.Salary,
                command.Active
            );

            await _employeeRepository.Add(employee);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
