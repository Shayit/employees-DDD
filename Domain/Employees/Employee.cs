using Domain.Primitives;

namespace Domain.Employees
{
    public sealed class Employee(string employeeId, string fullName, float salary, bool active) : AggregateRoot
    {
        public string EmployeeId { get; private set; } = employeeId;
        public string FullName { get; private set; } = fullName;
        public float Salary { get; private set; } = salary;
        public bool Active { get; set; } = active;

        public static Employee UpdateEmployee(string employeeId, string fullName, float salary, bool active)
        {
            return new Employee(employeeId, fullName, salary, active);
        }
    }
}
