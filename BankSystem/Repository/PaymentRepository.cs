using BankSystem.Data;
using BankSystem.Enum;
using BankSystem.Model;
using BankSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly BankContext context;

        public PaymentRepository(BankContext context) => this.context = context;

        public async Task AddPayment(Payment payment)
        {
            await context.Payments.AddAsync(payment);
            await context.SaveChangesAsync();
        }

        public async Task UpdatePayment(Payment payment)
        {
            context.Payments.Update(payment);
            await context.SaveChangesAsync();
        }

        public async Task DeletePayment(Payment payment)
        {
            context.Payments.Remove(payment);
            await context.SaveChangesAsync();
        }

        public async Task<Payment?> GetPaymentById(int paymentId)
        {
            return await context.Payments
                        .Include(p => p.Beneficiary)
                        .Include(p => p.User)
                        .FirstOrDefaultAsync(p => p.PaymentId == paymentId);
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByClientId(int clientId)
        {
            return await context.Payments
                        .Where(p => p.UserId == clientId)
                        .Include(p => p.Beneficiary)
                        .ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByBankUserId()
        {
            return await context.Payments
                        .Where(p => p.UserId ==2)
                        .Include(p => p.Beneficiary)
                        .Include(p => p.User)
                        .ToListAsync();
        }

        public async Task ApprovePayment(int paymentId)
        {
            var payment = await context.Payments.FindAsync(paymentId);
            if (payment != null)
            {
                payment.paymentStatus = PaymentStatus.Completed;
                payment.UserId = 2;
                context.Payments.Update(payment);
                await context.SaveChangesAsync();
            }
        }

        public async Task RejectPayment(int paymentId)
        {
            var payment = await context.Payments.FindAsync(paymentId);
            if (payment != null)
            {
                payment.paymentStatus = PaymentStatus.Cancelled;
                payment.UserId = 2;
                context.Payments.Update(payment);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Payment>> GetPaymentByBeneficiaryId(int beneficiary)
        {
            return await context.Payments
                        .Where(p => p.BeneficiaryId == beneficiary)
                        .Include(p => p.User)
                        .ToListAsync();
        }
    }
}
