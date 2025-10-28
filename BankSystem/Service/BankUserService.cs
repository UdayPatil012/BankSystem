using BankSystem.DTO;
using BankSystem.Enum;
using BankSystem.Model;
using BankSystem.Repository;
using BankSystem.Repository.IRepository;
using BankSystem.Service.IService;

namespace BankSystem.Service
{
    public class BankUserService : IBankUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IBeneficiaryRepository beneficiaryRepository;
        private readonly IDocumentRepository documentRepository;
        private readonly IPaymentRepository paymentRepository;
        private readonly ISalaryDisbursement salaryRepository;

        public BankUserService(
            IUserRepository userRepository,
            IEmployeeRepository employeeRepository,
            IBeneficiaryRepository beneficiaryRepository,
            IDocumentRepository documentRepository,
            IPaymentRepository paymentRepository,
            ISalaryDisbursement salaryRepository)
        {
            this.userRepository = userRepository;
            this.employeeRepository = employeeRepository;
            this.beneficiaryRepository = beneficiaryRepository;
            this.documentRepository = documentRepository;
            this.paymentRepository = paymentRepository;
            this.salaryRepository = salaryRepository;
        }

        // -------------------- Clients --------------------
        public async Task<PagedResult<User>> GetAllClientsAsync(int pageNumber = 1, int pageSize = 10)
        {
            var users = await userRepository.GetAll();
            var clients = users.Where(u => u.UserType == UserType.Client);

            int totalCount = clients.Count();

            var pagedClients = clients
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedResult<User>
            {
                Data = pagedClients,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<User> GetClientById(int clientId)
        {
            var client = await userRepository.GetById(clientId);
            if (client == null || client.UserType != UserType.Client)
                throw new InvalidOperationException("Invalid Client ID");
            return client;
        }

        public async Task AddClient(ClientDto clientDto)
        {
            var client = new User
            {
                UserName = clientDto.UserName,
                Password = clientDto.Password,
                Email = clientDto.Email,
                UserType = UserType.Client,
                CompanyName = clientDto.CompanyName,
                UserAddress = clientDto.UserAddress,
                ClientStatus = ClientStatus.Unverified
            };
            await userRepository.Add(client);
        }

        public async Task UpdateClient(int clientId, ClientDto clientDto)
        {
            var client = await GetClientById(clientId);
            client.UserName = clientDto.UserName;
            client.Email = clientDto.Email;
            client.CompanyName = clientDto.CompanyName;
            client.UserAddress = clientDto.UserAddress;
            await userRepository.Update(client);
        }

        public async Task DeleteClient(int clientId)
        {
            var client = await GetClientById(clientId);
            if (client == null) throw new InvalidOperationException("Client not found");
            await userRepository.Delete(client);
        }

        public async Task ApproveClient(int clientId)
        {
            var client = await GetClientById(clientId);
            if (client == null) throw new InvalidOperationException("Client not found");
            client.ClientStatus = ClientStatus.Verified;
            await userRepository.Update(client);
        }

        public async Task RejectClient(int clientId)
        {
            var client = await GetClientById(clientId);
            client.ClientStatus = ClientStatus.Suspended;
            await userRepository.Update(client);
        }

        // -------------------- Employees --------------------
        public async Task<IEnumerable<Employee>> GetEmployeesByClientId(int clientId)
        {
            if (clientId == 0 || clientId == 1 || clientId == 2) throw new InvalidOperationException("Enter Valid Client Id");
            return await employeeRepository.GetEmployeesByClientId(clientId);
        }

        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            var employee = await employeeRepository.GetEmployeeById(employeeId);
            if (employee == null) throw new InvalidOperationException("Employee not found");
            return employee;
        }

        public async Task AddEmployee(EmployeeDto employeeDto, int clientId)
        {
            var employee = new Employee
            {
                EmployeeName = employeeDto.EmployeeName,
                AccountNumber = employeeDto.AccountNumber,
                UserId = clientId,
                EmployeeStatus = EmployeeStatus.Pending
            };
            await employeeRepository.AddEmployee(employee);
        }

        public async Task UpdateEmployee(int employeeId, EmployeeDto employeeDto)
        {
            var employee = await GetEmployeeById(employeeId);
            employee.EmployeeName = employeeDto.EmployeeName;
            employee.AccountNumber = employeeDto.AccountNumber;
            await employeeRepository.UpdateEmployee(employee);
        }

        public async Task DeleteEmployee(int employeeId)
        {
            var employee = await GetEmployeeById(employeeId);
            if (employee == null) throw new InvalidOperationException("Employee not found");
            await employeeRepository.DeleteEmployee(employee);
        }

        public async Task ApproveEmployee(int employeeId)
        {
            var employee = await GetEmployeeById(employeeId);
            if (employee == null) throw new InvalidOperationException("Employee not found");
            employee.EmployeeStatus = EmployeeStatus.Approved;
            await employeeRepository.UpdateEmployee(employee);
        }

        public async Task RejectEmployee(int employeeId)
        {
            var employee = await GetEmployeeById(employeeId);
            if (employee == null) throw new InvalidOperationException("Employee not found");
            employee.EmployeeStatus = EmployeeStatus.Rejected;
            await employeeRepository.UpdateEmployee(employee);
        }

        // -------------------- Beneficiaries --------------------
        public async Task<IEnumerable<Beneficiary>> GetBeneficiariesByClientId(int clientId)
        {
            return await beneficiaryRepository.GetBeneficiariesByClientId(clientId);
        }

        public async Task<Beneficiary> GetBeneficiaryById(int beneficiaryId)
        {
            var ben = await beneficiaryRepository.GetBeneficiaryById(beneficiaryId);
            if (ben == null) throw new InvalidOperationException("Beneficiary not found");
            return ben;
        }

        public async Task AddBeneficiary(BeneficiaryDto beneficiaryDto, int clientId)
        {
            var beneficiary = new Beneficiary
            {
                BeneficiaryName = beneficiaryDto.BeneficiaryName,
                AccountNumber = beneficiaryDto.AccountNumber,
                UserId = clientId
            };
            await beneficiaryRepository.AddBeneficiary(beneficiary);
        }

        public async Task UpdateBeneficiary(int beneficiaryId, BeneficiaryDto beneficiaryDto)
        {
            var ben = await GetBeneficiaryById(beneficiaryId);
            ben.BeneficiaryName = beneficiaryDto.BeneficiaryName;
            ben.AccountNumber = beneficiaryDto.AccountNumber;
            await beneficiaryRepository.UpdateBeneficiary(ben);
        }

        public async Task DeleteBeneficiary(int beneficiaryId)
        {
            var ben = await GetBeneficiaryById(beneficiaryId);
            if (ben == null) throw new InvalidOperationException("Beneficiary not found");
            await beneficiaryRepository.DeleteBeneficiary(ben);
        }

        public async Task ApproveBeneficiary(int beneficiaryId)
        {
            var ben = await GetBeneficiaryById(beneficiaryId);
            await beneficiaryRepository.UpdateBeneficiary(ben);
            // Custom approval logic if needed
        }

        public async Task RejectBeneficiary(int beneficiaryId)
        {
            var ben = await GetBeneficiaryById(beneficiaryId);
            await beneficiaryRepository.DeleteBeneficiary(ben);
            // Custom reject logic if needed
        }

        // -------------------- Documents --------------------
        public async Task<IEnumerable<Document>> GetDocumentsByClientId(int clientId)
        {
            return await documentRepository.GetDocumentsByClientId(clientId);
        }

        public async Task<Document> GetDocumentById(int documentId)
        {
            var doc = await documentRepository.GetDocumentById(documentId);
            if (doc == null) throw new InvalidOperationException("Document not found");
            return doc;
        }

        public async Task AddDocument(DocumentDto documentDto, int clientId)
        {
            var doc = new Document
            {
                DocumentName = documentDto.DocumentName,
                DocumentType = documentDto.DocumentType,
                UserId = clientId,
                DocumentVerifiedStatus = DocumentVerifiedStatus.Pending
            };
            await documentRepository.AddDocument(doc);
        }

        public async Task UpdateDocument(int documentId, DocumentDto documentDto)
        {
            var doc = await GetDocumentById(documentId);
            doc.DocumentName = documentDto.DocumentName;
            doc.DocumentType = documentDto.DocumentType;
            await documentRepository.UpdateDocument(doc);
        }

        public async Task DeleteDocument(int documentId)
        {
            var doc = await GetDocumentById(documentId);
            await documentRepository.DeleteDocument(doc);
        }

        public async Task ApproveDocument(int documentId)
        {
            var doc = await GetDocumentById(documentId);
            doc.DocumentVerifiedStatus = DocumentVerifiedStatus.Approved;
            await documentRepository.UpdateDocument(doc);
        }

        public async Task RejectDocument(int documentId)
        {
            var doc = await GetDocumentById(documentId);
            doc.DocumentVerifiedStatus = DocumentVerifiedStatus.Rejected;
            await documentRepository.UpdateDocument(doc);
        }

        // -------------------- Payments --------------------
        public async Task<IEnumerable<Payment>> GetPaymentsByClientId(int clientId)
        {
            return await paymentRepository.GetPaymentsByClientId(clientId);
        }

        public async Task<Payment> GetPaymentById(int paymentId)
        {
            var payment = await paymentRepository.GetPaymentById(paymentId);
            if (payment == null) throw new InvalidOperationException("Payment not found");
            return payment;
        }

        public async Task ProcessPayment(PaymentDto paymentDto, int beneficiaryId, int clientId)
        {
            var payment = new Payment
            {
                Amount = paymentDto.Amount,
                paymentStatus = PaymentStatus.Pending,
                BeneficiaryId = beneficiaryId,
                UserId = clientId
            };

            if (paymentDto.PaymentStatus == PaymentStatus.Completed)
            {
                await paymentRepository.AddPayment(payment);
            }
        }

        public async Task ApprovePayment(int paymentId)
        {
            await paymentRepository.ApprovePayment(paymentId);
        }

        public async Task RejectPayment(int paymentId)
        {
            await paymentRepository.RejectPayment(paymentId);
        }

        // -------------------- Salary Disbursement --------------------
        public async Task<IEnumerable<SalaryDisbursement>> GetDisbursementsByClientId(int clientId)
        {
            return await salaryRepository.GetDisbursementsByClientId(clientId);
        }

        public async Task<IEnumerable<SalaryDisbursement>> GetDisbursementsByEmployeeId(int employeeId)
        {
            return await salaryRepository.GetDisbursementsByEmployeeId(employeeId);
        }

        public async Task<SalaryDisbursement> GetDisbursementById(int disbursementId)
        {
            var disbursement = await salaryRepository.GetDisbursementById(disbursementId);
            if (disbursement == null) throw new InvalidOperationException("Salary disbursement not found");
            return disbursement;
        }

        public async Task AddSalaryDisbursement(SalaryDisbursementDto salaryDto, int employeeId, int clientId)
        {
            var disbursement = new SalaryDisbursement
            {
                EmployeeId = employeeId,
                UserId = clientId,
                PaymentStatus = PaymentStatus.Pending
            };

            if (salaryDto.PaymentStatus == PaymentStatus.Completed)
            {
                await salaryRepository.AddDisbursement(disbursement);
            }
        }

        public async Task UpdateSalaryDisbursement(int disbursementId, SalaryDisbursementDto salaryDto)
        {
            var disbursement = await GetDisbursementById(disbursementId);
            disbursement.PaymentStatus = salaryDto.PaymentStatus;
            await salaryRepository.UpdateDisbursement(disbursement);
        }

        public async Task DeleteSalaryDisbursement(int disbursementId)
        {
            var disbursement = await GetDisbursementById(disbursementId);
            await salaryRepository.DeleteDisbursement(disbursement);
        }

        public async Task ApproveSalaryDisbursement(int disbursementId)
        {
            await salaryRepository.ApproveDisbursement(disbursementId);
        }

        public async Task RejectSalaryDisbursement(int disbursementId)
        {
            await salaryRepository.RejectDisbursement(disbursementId);
        }
    }
}

