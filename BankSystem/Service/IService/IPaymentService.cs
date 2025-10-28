using BankSystem.DTO;
using BankSystem.Enum;
using BankSystem.Model;

namespace BankSystem.Service.IService
{
    public interface IPaymentService
    {
        Task<Payment> MakePaymentAsync(int clientId, int beneficiaryId, PaymentDto paymentDto);
        Task<IEnumerable<Payment>> GetPaymentHistoryByClientIdAsync(int clientId);
        Task<Payment?> GetPaymentByIdAsync(int paymentId);
        Task UpdatePaymentStatusAsync(int paymentId, PaymentStatus status);
    }
}
