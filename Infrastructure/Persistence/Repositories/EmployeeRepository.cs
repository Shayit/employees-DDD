using Domain.Employees;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class EmployeeRepository(ApplicationDbContext context) : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task Add(Employee employee) => await _context.Employees.AddAsync(employee);
        public void Delete(Employee employee) => _context.Employees.Remove(employee);
        public void Update(Employee employee) => _context.Employees.Update(employee);
        public async Task<bool> ExistsAsync(string id) => await _context.Employees.AnyAsync(employee => employee.EmployeeId == id);
        public async Task<List<Employee>> GetAll() => await _context.Employees.ToListAsync();
        public async Task<Employee?> GetByIdAsync(string id) => await _context.Employees.SingleOrDefaultAsync(e => e.EmployeeId == id);
    }
}
