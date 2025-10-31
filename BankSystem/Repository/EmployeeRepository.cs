using BankSystem.Data;
using BankSystem.Model;
using BankSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly BankContext context;

        public EmployeeRepository(BankContext context) => this.context = context;
        public async Task AddEmployee(Employee employee)
        {
            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();
        }

        public async Task DeleteEmployee(Employee employee)
        {
            context.Employees.Remove(employee);
            await context.SaveChangesAsync();

        }

        public async Task<Employee?> GetEmployeeById(int employeeId)
        {
            return await context.Employees.FindAsync(employeeId);

        }

        public async Task<IEnumerable<Employee>> GetEmployeesByClientId(int clientId)
        {
            var Isclient = await context.Users.AnyAsync(u => u.UserId == clientId && u.UserType == Enum.UserType.Client);

            if (!Isclient) throw new InvalidOperationException("Invalid Client Id");

            return await context.Employees.Where(e => e.UserId == clientId).ToListAsync();

        }

        public async Task UpdateEmployee(Employee employee)
        {
            context.Employees.Update(employee);
            await context.SaveChangesAsync();
        }

        public async Task GetAllEmployees()
        {
            var employees = await context.Employees.ToListAsync();
        }
    }
}
