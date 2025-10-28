using BankSystem.DTO;
using BankSystem.Model;

namespace BankSystem.Service.IService
{
    public interface ISalaryDisbursementService
    {
        Task<SalaryDisbursement> DisburseSalaryAsync(SalaryDisbursementDto dto, int employeeId);
        Task<IEnumerable<SalaryDisbursement>> GetSalariesByClientIdAsync(int employeeId);
        Task<SalaryDisbursement?> GetSalaryByIdAsync(int salaryDisbursementId);
        Task<IEnumerable<SalaryDisbursement>> GetSalariesByEmployeeIdAsync(int empployeeID);
    }
}
