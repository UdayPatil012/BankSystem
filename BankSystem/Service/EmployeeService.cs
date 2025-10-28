using BankSystem.DTO;
using BankSystem.Model;
using BankSystem.Repository;
using BankSystem.Repository.IRepository;
using BankSystem.Service.IService;

namespace BankSystem.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly ISalaryDisbursement salaryRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, ISalaryDisbursement salaryRepository)
        {
            this.employeeRepository = employeeRepository;
            this.salaryRepository = salaryRepository;
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int employeeId)
        {
            return await employeeRepository.GetEmployeeById(employeeId);
        }

        public async Task<IEnumerable<SalaryDisbursement>> GetSalarySlipsAsync(int employeeId)
        {
            var employee = await employeeRepository.GetEmployeeById(employeeId);
            if (employee == null)
                throw new InvalidOperationException("Employee not found.");

            return await salaryRepository.GetDisbursementsByEmployeeId(employeeId);
        }
    }
}

