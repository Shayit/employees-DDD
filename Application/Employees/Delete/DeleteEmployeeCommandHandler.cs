using Domain.Employees;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Employees.Delete
{
    internal sealed class DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteEmployeeCommand, ErrorOr<Unit>>
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        public async Task<ErrorOr<Unit>> Handle(DeleteEmployeeCommand command, CancellationToken cancellationToken)
        {
            if (await _employeeRepository.GetByIdAsync(command.Id) is not Employee employee)
            {
                return Error.NotFound("Employee.NotFound", "The employee with the provide Id was not found.");
            }

            _employeeRepository.Delete(employee);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
