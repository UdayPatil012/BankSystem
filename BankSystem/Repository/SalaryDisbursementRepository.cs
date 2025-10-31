using BankSystem.Data;
using BankSystem.Enum;
using BankSystem.Model;
using BankSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Repository
{
    public class SalaryDisbursementRepository : ISalaryDisbursement
    {
        private readonly BankContext context;

        public SalaryDisbursementRepository(BankContext context) => this.context = context;

        public async Task AddDisbursement(SalaryDisbursement salaryDisbursement)
        {
            await context.SalaryDisbursements.AddAsync(salaryDisbursement);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SalaryDisbursement>> GetAllSalary()
        {
            return await context.SalaryDisbursements.ToListAsync();
        }

        public async Task UpdateDisbursement(SalaryDisbursement salaryDisbursement)
        {
            context.SalaryDisbursements.Update(salaryDisbursement);
            await context.SaveChangesAsync();
        }

        public async Task DeleteDisbursement(SalaryDisbursement salaryDisbursement)
        {
            context.SalaryDisbursements.Remove(salaryDisbursement);
            await context.SaveChangesAsync();
        }

        public async Task<SalaryDisbursement?> GetDisbursementById(int disbursementId)
        {
            return await context.SalaryDisbursements
                        .Include(s => s.Employee)
                        .Include(s => s.User)
                        .FirstOrDefaultAsync(s => s.SalaryDisbursementId == disbursementId);
        }

        public async Task<IEnumerable<SalaryDisbursement>> GetDisbursementsByClientId(int clientId)
        {
            return await context.SalaryDisbursements
                        .Where(s => s.UserId == clientId)
                        .Include(s => s.Employee)
                        .ToListAsync();
        }

        public async Task<IEnumerable<SalaryDisbursement>> GetDisbursementsByBankUserId()
        {
            return await context.SalaryDisbursements
                        .Where(s => s.UserId == 2)
                        .Include(s => s.Employee)
                        .Include(s => s.User)
                        .ToListAsync();
        }

        public async Task ApproveDisbursement(int disbursementId)
        {
            var disbursement = await context.SalaryDisbursements.FindAsync(disbursementId);
            if (disbursement != null)
            {
                disbursement.PaymentStatus = PaymentStatus.Completed;
                disbursement.UserId = 2;
                context.SalaryDisbursements.Update(disbursement);
                await context.SaveChangesAsync();
            }
        }

        public async Task RejectDisbursement(int disbursementId)
        {
            var disbursement = await context.SalaryDisbursements.FindAsync(disbursementId);
            if (disbursement != null)
            {
                disbursement.PaymentStatus = PaymentStatus.Cancelled;
                disbursement.UserId = 2;
                context.SalaryDisbursements.Update(disbursement);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SalaryDisbursement>> GetDisbursementsByEmployeeId(int employeeId)
        {
            return await context.SalaryDisbursements
                        .Where(s => s.EmployeeId == employeeId)
                        .Include(s => s.Employee)
                        .ToListAsync();
        }
    }
}
