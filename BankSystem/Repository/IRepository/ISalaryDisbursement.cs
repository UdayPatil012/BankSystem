using BankSystem.Model;

namespace BankSystem.Repository.IRepository
{
    public interface ISalaryDisbursement
    {
        Task AddDisbursement(SalaryDisbursement salaryDisbursement);
        Task UpdateDisbursement(SalaryDisbursement salaryDisbursement);
        Task DeleteDisbursement(SalaryDisbursement salaryDisbursement);
        Task<SalaryDisbursement?> GetDisbursementById(int disbursementId);
        Task<IEnumerable<SalaryDisbursement>> GetDisbursementsByClientId(int clientId);
        Task<IEnumerable<SalaryDisbursement>> GetDisbursementsByBankUserId();
        Task ApproveDisbursement(int disbursementId);
        Task RejectDisbursement(int disbursementId);
        Task<IEnumerable<SalaryDisbursement>> GetDisbursementsByEmployeeId(int employeeId);

    }
}
