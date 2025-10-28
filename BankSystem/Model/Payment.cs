using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BankSystem.Enum;
namespace BankSystem.Model
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey("Beneficiary")]
        public int? BeneficiaryId { get; set; }
        public Beneficiary? Beneficiary { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public PaymentStatus paymentStatus { get; set; }= PaymentStatus.Pending;

        public DateTime PaymentDate { get; set; } = DateTime.Now;
    }
}
