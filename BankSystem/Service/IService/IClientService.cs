using BankSystem.DTO;
using BankSystem.Model;
using BankSystem.Repository;

namespace BankSystem.Service.IService
{

    public interface IClientService
    {
        // Employees
        Task<PagedResult<EmployeeDto>> GetMyEmployeesAsync(int clientId, int pageNumber = 1, int pageSize = 10);

        Task<EmployeeDto> AddEmployeeAsync(EmployeeDto employeeDto, int clientId);
        Task UpdateEmployeeAsync(EmployeeDto employeeDto, int employeeId);
        Task DeleteEmployeeAsync(int employeeId);
        Task<EmployeeDto?> GetEmployeeByIdAsync(int employeeId);

        // Documents
        Task<IEnumerable<DocumentDto>> GetMyDocumentsAsync(int clientId);
        Task<DocumentDto> UploadDocumentAsync(DocumentDto documentDto, int clientId);
        Task<DocumentDto?> GetDocumentByIdAsync(int documentId);

        // Salary Disbursement
        Task<IEnumerable<SalaryDisbursementDto>> GetMySalaryDisbursementsAsync(int clientId);
        Task<SalaryDisbursementDto?> GetSalaryDisbursementByIdAsync(int salaryDisbursementId);

        // Beneficiaries
        Task<IEnumerable<BeneficiaryDto>> GetMyBeneficiariesAsync(int clientId);
        Task<BeneficiaryDto> AddBeneficiaryAsync(BeneficiaryDto beneficiaryDto, int clientId);
        Task<BeneficiaryDto?> GetBeneficiaryByIdAsync(int beneficiaryId);
        Task UpdateBeneficiaryAsync(BeneficiaryDto beneficiaryDto, int beneficiaryId);
        Task DeleteBeneficiaryAsync(int beneficiaryId);

        //Payments

        Task<IEnumerable<PaymentDto>> GetMyPaymentsAsync(int clientId);
        Task<PaymentDto?> GetPaymentByIdAsync(int paymentId);
        Task<PaymentDto> MakePaymentAsync(int clientId, int beneficiaryId, double amount, string remarks);
        Task<bool> CancelPaymentAsync(int paymentId, int clientId);

    }
}
