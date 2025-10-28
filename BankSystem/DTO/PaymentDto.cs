using BankSystem.Enum;

namespace BankSystem.DTO
{
    public class PaymentDto
    {
        public double Amount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.Now;
    }
}
