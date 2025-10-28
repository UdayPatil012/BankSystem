using BankSystem.DTO;
using BankSystem.Model;

namespace BankSystem.Service.IService
{
    public interface IEmployeeService
    {
        Task<Employee?> GetEmployeeByIdAsync(int employeeId);
        Task<IEnumerable<SalaryDisbursement>> GetSalarySlipsAsync(int employeeId);
    }
}
