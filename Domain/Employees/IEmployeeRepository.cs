namespace Domain.Employees
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAll();
        Task<Employee?> GetByIdAsync(string id);
        Task<bool> ExistsAsync(string id);
        Task Add(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
    }
}
