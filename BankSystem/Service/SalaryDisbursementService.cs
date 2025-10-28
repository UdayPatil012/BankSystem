using BankSystem.DTO;
using BankSystem.Model;
using BankSystem.Repository;
using BankSystem.Repository.IRepository;
using BankSystem.Service.IService;

namespace BankSystem.Service
{
    public class SalaryDisbursementService : ISalaryDisbursementService
    {
        private readonly ISalaryDisbursement salaryRepository;

        public SalaryDisbursementService(ISalaryDisbursement salaryRepository)
        {
            this.salaryRepository = salaryRepository;
        }

        public async Task<SalaryDisbursement> DisburseSalaryAsync(SalaryDisbursementDto dto, int employeeId)
        {
            var salary = new SalaryDisbursement
            {
                EmployeeId = employeeId,
                PaymentStatus = dto.PaymentStatus,
                DisbursementDate = DateTime.Now
            };
                   
            await salaryRepository.AddDisbursement(salary);
            return salary;
        }

        public async Task<IEnumerable<SalaryDisbursement>> GetSalariesByClientIdAsync(int clientid)
        {
            return await salaryRepository.GetDisbursementsByClientId(clientid);
        }

        public async Task<SalaryDisbursement?> GetSalaryByIdAsync(int salaryDisbursementId)
        {
            return await salaryRepository.GetDisbursementById(salaryDisbursementId);
        }
        public async Task<IEnumerable<SalaryDisbursement>> GetSalariesByEmployeeIdAsync(int empployeeID)
        {
            return await salaryRepository.GetDisbursementsByEmployeeId(empployeeID);
        }
    }
}
