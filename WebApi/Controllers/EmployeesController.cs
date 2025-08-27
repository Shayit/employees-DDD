using Application.Employees.Create;
using Application.Employees.Delete;
using Application.Employees.GetAll;
using Application.Employees.GetById;
using Application.Employees.Update;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("employees")]
    public class EmployeesController(ISender mediator) : ApiController
    {
        private readonly ISender _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employeeResult = await _mediator.Send(new GetAllEmployeeQuery());

            return employeeResult.Match(
            employees => Ok(employees),
            errors => Problem(errors));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var employeeResult = await _mediator.Send(new GetEmployeeByIdQuery(id));

            return employeeResult.Match(
                employee => Ok(employee),
                errors => Problem(errors));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeCommand command)
        {
            var createEmployeeResult = await _mediator.Send(command);

            return createEmployeeResult.Match(
                employee => Ok(),
                errors => Problem(errors));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateEmployeeCommand command)
        {
            if (command.EmployeeId != id)
            {
                List<Error> errors =
                [
                    Error.Validation("Employee.UpdateInvalid", "The request Id does not match with the url Id.")
                ];
                return Problem(errors);
            }

            var updateResult = await _mediator.Send(command);

            return updateResult.Match(
                customerId => NoContent(),
                errors => Problem(errors)
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleteResult = await _mediator.Send(new DeleteEmployeeCommand(id));

            return deleteResult.Match(
                customerId => NoContent(),
                errors => Problem(errors));
        }
    }
}
