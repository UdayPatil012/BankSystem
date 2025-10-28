using BankSystem.Model;

namespace BankSystem.Repository.IRepository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesByClientId(int clientId); 
        Task<Employee?> GetEmployeeById(int employeeId); 
        Task AddEmployee(Employee employee); 
        Task UpdateEmployee(Employee employee); 
        Task DeleteEmployee(Employee employee); 
    }
}
