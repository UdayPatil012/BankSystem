using BankSystem.DTO;
using BankSystem.Model;

namespace BankSystem.Service.IService
{
    public interface IBankUserService
    {
        // -------------------- Clients --------------------
        Task<List<User>> GetAllClientsAsync();
        Task<User> GetClientById(int clientId);
        Task<User> AddClient(ClientDto clientDto);
        Task UpdateClient(int clientId, ClientDto clientDto);
        Task DeleteClient(int clientId);
        Task ApproveClient(int clientId);
        Task RejectClient(int clientId);

        // -------------------- Employees --------------------
        Task<IEnumerable<Employee>> GetEmployeesByClientId(int clientId);
        Task<Employee> GetEmployeeById(int employeeId);
        Task AddEmployee(EmployeeDto employeeDto, int clientId);
        Task UpdateEmployee(int employeeId, EmployeeDto employeeDto);
        Task DeleteEmployee(int employeeId);
        Task ApproveEmployee(int employeeId);
        Task RejectEmployee(int employeeId);

        // -------------------- Beneficiaries --------------------
        Task<IEnumerable<Beneficiary>> GetBeneficiariesByClientId(int clientId);
        Task<Beneficiary> GetBeneficiaryById(int beneficiaryId);
        Task AddBeneficiary(BeneficiaryDto beneficiaryDto, int clientId);
        Task UpdateBeneficiary(int beneficiaryId, BeneficiaryDto beneficiaryDto);
        Task DeleteBeneficiary(int beneficiaryId);
        Task ApproveBeneficiary(int beneficiaryId);
        Task RejectBeneficiary(int beneficiaryId);
        Task GetAllBeneficiary();

        // -------------------- Documents --------------------
        Task<IEnumerable<Document>> GetDocumentsByClientId(int clientId);
        Task<Document> GetDocumentById(int documentId);
        Task AddDocument(DocumentDto documentDto, int clientId);
        Task UpdateDocument(int documentId, DocumentDto documentDto);
        Task DeleteDocument(int documentId);
        Task ApproveDocument(int documentId);
        Task RejectDocument(int documentId);

        // -------------------- Payments --------------------
        Task<IEnumerable<Payment>> GetAllPayment();
        Task<IEnumerable<Payment>> GetPaymentsByClientId(int clientId);
        Task<Payment> GetPaymentById(int paymentId);
        Task ProcessPayment(PaymentDto paymentDto, int beneficiaryId, int clientId);
        Task ApprovePayment(int paymentId);
        Task RejectPayment(int paymentId);

        // -------------------- Salary Disbursement --------------------
        Task<IEnumerable<SalaryDisbursement>> GetAllSalary();
        Task<IEnumerable<SalaryDisbursement>> GetDisbursementsByClientId(int clientId);
        Task<IEnumerable<SalaryDisbursement>> GetDisbursementsByEmployeeId(int employeeId);
        Task<SalaryDisbursement> GetDisbursementById(int disbursementId);
        Task AddSalaryDisbursement(SalaryDisbursementDto salaryDto, int employeeId, int clientId, double amount);
        Task UpdateSalaryDisbursement(int disbursementId, SalaryDisbursementDto salaryDto);
        Task DeleteSalaryDisbursement(int disbursementId);
        Task ApproveSalaryDisbursement(int disbursementId);
        Task RejectSalaryDisbursement(int disbursementId);
    }
}

