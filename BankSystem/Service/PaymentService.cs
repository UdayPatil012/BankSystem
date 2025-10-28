using BankSystem.DTO;
using BankSystem.Enum;
using BankSystem.Model;
using BankSystem.Repository.IRepository;
using BankSystem.Service.IService;

namespace BankSystem.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository paymentRepository;
        private readonly IUserRepository userRepository;
        private readonly IBeneficiaryRepository beneficiaryRepository;

        public PaymentService(
            IPaymentRepository paymentRepository,
            IUserRepository userRepository,
            IBeneficiaryRepository beneficiaryRepository)
        {
            this.paymentRepository = paymentRepository;
            this.userRepository = userRepository;
            this.beneficiaryRepository = beneficiaryRepository;
        }

        public async Task<Payment> MakePaymentAsync(int clientId, int beneficiaryId, PaymentDto paymentDto)
        {
            var user = await userRepository.GetById(clientId);
            if (user == null || user.UserType != UserType.Client)
                throw new Exception("Invalid Client.");

            var beneficiary = await beneficiaryRepository.GetBeneficiaryById(beneficiaryId);
            if (beneficiary == null)
                throw new Exception("Beneficiary not found.");

            var payment = new Payment
            {
                UserId = clientId,
                BeneficiaryId = beneficiaryId,
                Amount = paymentDto.Amount,
                paymentStatus = PaymentStatus.Pending,
                PaymentDate = DateTime.Now
            };

            await paymentRepository.AddPayment(payment);
            return payment;
        }

        public async Task<IEnumerable<Payment>> GetPaymentHistoryByClientIdAsync(int clientId)
        {
            return await paymentRepository.GetPaymentsByClientId(clientId);
        }

        public async Task<Payment?> GetPaymentByIdAsync(int paymentId)
        {
            return await paymentRepository.GetPaymentById(paymentId);
        }

        public async Task UpdatePaymentStatusAsync(int paymentId, PaymentStatus status)
        {
            var payment = await paymentRepository.GetPaymentById(paymentId);
            if (payment == null) throw new Exception("Payment not found.");

            payment.paymentStatus = status;
            await paymentRepository.UpdatePayment(payment);
        }
    }
}
