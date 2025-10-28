using BankSystem.DTO;
using BankSystem.Model;
using BankSystem.Repository;
using BankSystem.Repository.IRepository;
using BankSystem.Service.IService;

namespace BankSystem.Service
{
    public class ClientService : IClientService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IDocumentRepository documentRepository;
        private readonly ISalaryDisbursement salaryDisbursementRepository;
        private readonly IBeneficiaryRepository beneficiaryRepository;
        private readonly IPaymentRepository paymentRepository;
        private readonly IUserRepository userrepository;

        public ClientService(
            IEmployeeRepository employeeRepository,
            IDocumentRepository documentRepository,
            ISalaryDisbursement salaryDisbursementRepository,
            IBeneficiaryRepository beneficiaryRepository,
            IPaymentRepository paymentRepository,
            IUserRepository userRepository)
        {
            this.employeeRepository = employeeRepository;
            this.documentRepository = documentRepository;
            this.salaryDisbursementRepository = salaryDisbursementRepository;
            this.beneficiaryRepository = beneficiaryRepository;
            this.paymentRepository = paymentRepository;
            this.userrepository = userRepository;
        }

        // ------------------- Employees -------------------
        public async Task<PagedResult<EmployeeDto>> GetMyEmployeesAsync(int clientId, int pageNumber = 1, int pageSize = 10)
        {
            var employees = await employeeRepository.GetEmployeesByClientId(clientId);
            if (!employees.Any()) throw new InvalidOperationException("No Employees Found");

            var totalCount = employees.Count();

            var pagedEmployees = employees
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(e => new EmployeeDto
                {
                    EmployeeName = e.EmployeeName,
                    AccountNumber = e.AccountNumber,
                    EmployeeStatus = e.EmployeeStatus
                })
                .ToList();

            return new PagedResult<EmployeeDto>
            {
                Data = pagedEmployees,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<EmployeeDto> AddEmployeeAsync(EmployeeDto employeeDto, int clientId)
        {
            var employee = new Employee
            {
                EmployeeName = employeeDto.EmployeeName,
                AccountNumber = employeeDto.AccountNumber,
                UserId = clientId,
                EmployeeStatus = Enum.EmployeeStatus.Pending
            };

            await employeeRepository.AddEmployee(employee);
            return employeeDto;
        }

        public async Task UpdateEmployeeAsync(EmployeeDto employeeDto, int employeeId)
        {
            var employee = await employeeRepository.GetEmployeeById(employeeId);
            if (employee == null) throw new InvalidOperationException("Employee Not Found");

            employee.EmployeeName = employeeDto.EmployeeName;
            employee.AccountNumber = employeeDto.AccountNumber;

            await employeeRepository.UpdateEmployee(employee);
        }

        public async Task DeleteEmployeeAsync(int employeeId)
        {
            var employee = await employeeRepository.GetEmployeeById(employeeId);
            if (employee == null) throw new InvalidOperationException("Employee Not Found");

            await employeeRepository.DeleteEmployee(employee);
        }

        public async Task<EmployeeDto?> GetEmployeeByIdAsync(int employeeId)
        {
            var employee = await employeeRepository.GetEmployeeById(employeeId);
            if (employee == null) throw new InvalidOperationException("Employee Not Found");

            return new EmployeeDto
            {
                EmployeeName = employee.EmployeeName,
                AccountNumber = employee.AccountNumber,
                EmployeeStatus = employee.EmployeeStatus
            };
        }

        // ------------------- Documents -------------------
        public async Task<IEnumerable<DocumentDto>> GetMyDocumentsAsync(int clientId)
        {
            var documents = await documentRepository.GetDocumentsByClientId(clientId);
            if (!documents.Any()) throw new InvalidOperationException("No Documents Found");
            return documents.Select(d => new DocumentDto
            {
                DocumentName = d.DocumentName,
                DocumentType = d.DocumentType,
                DocumentVerifiedStatus = d.DocumentVerifiedStatus
            });
        }

        public async Task<DocumentDto> UploadDocumentAsync(DocumentDto documentDto, int clientId)
        {
            if (clientId == 1 || clientId == 2)
            {
                throw new InvalidOperationException("SuperAdmin Or BankUser cannot upload documents");
            }

            var document = new Document
            {
                DocumentName = documentDto.DocumentName,
                DocumentType = documentDto.DocumentType,
                DocumentVerifiedStatus = Enum.DocumentVerifiedStatus.Pending,
                UserId = clientId
            };

            await documentRepository.AddDocument(document);
            return documentDto;
        }

        public async Task<DocumentDto?> GetDocumentByIdAsync(int documentId)
        {
            var document = await documentRepository.GetDocumentById(documentId);
            if (document == null) return null;

            return new DocumentDto
            {
                DocumentName = document.DocumentName,
                DocumentType = document.DocumentType,
                DocumentVerifiedStatus = document.DocumentVerifiedStatus
            };
        }

        // ------------------- Salary Disbursement -------------------
        public async Task<IEnumerable<SalaryDisbursementDto>> GetMySalaryDisbursementsAsync(int clientId)
        {
            var salaries = await salaryDisbursementRepository.GetDisbursementsByClientId(clientId);
            if (!salaries.Any()) throw new InvalidOperationException("No Salary Disbursements Found");
            return salaries.Select(s => new SalaryDisbursementDto
            {
                PaymentStatus = s.PaymentStatus,
                Amount = s.Amount,
            });
        }

        public async Task<SalaryDisbursementDto?> GetSalaryDisbursementByIdAsync(int salaryDisbursementId)
        {
            var disbursement = await salaryDisbursementRepository.GetDisbursementById(salaryDisbursementId);
            if (disbursement == null) throw new InvalidOperationException("Salary Disbursement Not Found");

            return new SalaryDisbursementDto
            {
                PaymentStatus = disbursement.PaymentStatus,
                Amount = disbursement.Amount
            };
        }

        // ------------------- Beneficiaries -------------------
        public async Task<IEnumerable<BeneficiaryDto>> GetMyBeneficiariesAsync(int clientId)
        {
            if (clientId == 1 || clientId == 2)
            {
                throw new InvalidOperationException("SuperAdmin Or BankUser cannot have beneficiaries");
            }

            var beneficiaries = await beneficiaryRepository.GetBeneficiariesByClientId(clientId);
            if (!beneficiaries.Any()) throw new InvalidOperationException("No Beneficiaries Found");
            return beneficiaries.Select(b => new BeneficiaryDto
            {
                BeneficiaryName = b.BeneficiaryName,
                AccountNumber = b.AccountNumber
            });
        }

        public async Task<BeneficiaryDto> AddBeneficiaryAsync(BeneficiaryDto beneficiaryDto, int clientId)
        {
            if (clientId == 1 || clientId == 2) throw new Exception("BankUser And SuperAdmin Cannot Add Beneficiary");

            var beneficiary = new Beneficiary
            {
                BeneficiaryName = beneficiaryDto.BeneficiaryName,
                AccountNumber = beneficiaryDto.AccountNumber,
                UserId = clientId,
                BeneficiaryStatus = Enum.BeneficiaryStatus.Pending

            };

            await beneficiaryRepository.AddBeneficiary(beneficiary);
            return beneficiaryDto;
        }

        public async Task<BeneficiaryDto?> GetBeneficiaryByIdAsync(int beneficiaryId)
        {
            var beneficiary = await beneficiaryRepository.GetBeneficiaryById(beneficiaryId);
            if (beneficiary == null) throw new InvalidOperationException("Beneficiary Not Found");

            return new BeneficiaryDto
            {
                BeneficiaryName = beneficiary.BeneficiaryName,
                AccountNumber = beneficiary.AccountNumber
            };
        }

        public async Task UpdateBeneficiaryAsync(BeneficiaryDto beneficiaryDto, int beneficiaryId)
        {
            var beneficiary = await beneficiaryRepository.GetBeneficiaryById(beneficiaryId);
            if (beneficiary == null) throw new InvalidOperationException("Beneficiary Not Found");

            beneficiary.BeneficiaryName = beneficiaryDto.BeneficiaryName;
            beneficiary.AccountNumber = beneficiaryDto.AccountNumber;

            await beneficiaryRepository.UpdateBeneficiary(beneficiary);
        }

        public async Task DeleteBeneficiaryAsync(int beneficiaryId)
        {
            var beneficiary = await beneficiaryRepository.GetBeneficiaryById(beneficiaryId);
            if (beneficiary == null) throw new InvalidOperationException("Beneficiary Not Found");

            await beneficiaryRepository.DeleteBeneficiary(beneficiary);
        }

        // ------------------- Payments -------------------
        public async Task<IEnumerable<PaymentDto>> GetMyPaymentsAsync(int clientId)
        {
            var payments = await paymentRepository.GetPaymentsByClientId(clientId);
            if (!payments.Any()) throw new InvalidOperationException("No Payments Found");
            return payments.Select(p => new PaymentDto
            {
                Amount = p.Amount,
                PaymentDate = p.PaymentDate,
                PaymentStatus = p.paymentStatus
            });
        }

        public async Task<PaymentDto?> GetPaymentByIdAsync(int paymentId)
        {
            var payment = await paymentRepository.GetPaymentById(paymentId);
            if (payment == null) throw new InvalidOperationException("Payment Not Found");

            return new PaymentDto
            {
                Amount = payment.Amount,
                PaymentDate = payment.PaymentDate,
                PaymentStatus = payment.paymentStatus
            };
        }

        public async Task<PaymentDto> MakePaymentAsync(int clientId, int beneficiaryId, double amount, string remarks)
        {
            var client = await userrepository.GetById(clientId);
            if (client == null || client.UserType != Enum.UserType.Client) throw new Exception("Invalid client.");
            var beneficiary = await beneficiaryRepository.GetBeneficiaryById(beneficiaryId);
            if (beneficiary == null) throw new InvalidOperationException("Beneficiary not found.");

            if (amount <= 0)
                throw new Exception("Invalid payment amount.");
            if (client.Balance < amount)
                throw new Exception("Insufficient balance.");

            client.Balance -= amount;

            var payment = new Payment
            {
                UserId = clientId,
                BeneficiaryId = beneficiaryId,
                Amount = amount,
                PaymentDate = DateTime.Now,
                paymentStatus = Enum.PaymentStatus.Pending
            };

            await paymentRepository.AddPayment(payment);
            await userrepository.Update(client);

            return new PaymentDto
            {
                Amount = payment.Amount,
                PaymentDate = payment.PaymentDate,
                PaymentStatus = payment.paymentStatus
            };
        }

        public async Task<bool> CancelPaymentAsync(int paymentId, int clientId)
        {
            var payment = await paymentRepository.GetPaymentById(paymentId);
            if (payment == null || payment.UserId != clientId)
                return false;

            if (payment.paymentStatus == Enum.PaymentStatus.Completed)
                throw new Exception("Cannot cancel completed payment.");

            payment.paymentStatus = Enum.PaymentStatus.Cancelled;
            await paymentRepository.UpdatePayment(payment);
            return true;
        }
    }
}
