using BankSystem.Model;

namespace BankSystem.Repository.IRepository
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetAllPayment();
        Task AddPayment(Payment payment);
        Task UpdatePayment(Payment payment);
        Task DeletePayment(Payment payment);
        Task<Payment?> GetPaymentById(int paymentId);
        Task<IEnumerable<Payment>> GetPaymentsByClientId(int clientId);
        Task<IEnumerable<Payment>> GetPaymentsByBankUserId();
        Task ApprovePayment(int paymentId);
        Task RejectPayment(int paymentId);
        Task<IEnumerable<Payment>> GetPaymentByBeneficiaryId(int beneficiary);
    }
}
