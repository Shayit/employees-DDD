namespace Application.Employees.Common
{
    public record EmployeeResponse(
        string EmployeeId,
        string FullName,
        float Salary,
        bool Active
    );
}
