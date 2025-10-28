using BankSystem.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Model
{
    public class Beneficiary
    {
        [Key]
        public int BeneficiaryId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        [MaxLength(100)]

        public string BeneficiaryName { get; set; }

        [Required]
        [MaxLength(20)]

        public string AccountNumber { get; set; }

        public BeneficiaryStatus? BeneficiaryStatus { get; set; }
    }
}
