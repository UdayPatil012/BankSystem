using BankSystem.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace BankSystem.Model
{
    public class SalaryDisbursement
    {
        [Key]
        public int SalaryDisbursementId { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        [Required]
        public double Amount { get; set; }

        public DateTime DisbursementDate { get; set; } = DateTime.Now;

        public PaymentStatus PaymentStatus { get; set; }
    }
}
