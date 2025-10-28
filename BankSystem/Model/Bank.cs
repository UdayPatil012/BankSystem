using System.ComponentModel.DataAnnotations;

namespace BankSystem.Model
{
    public class Bank
    {
        [Key]
        public int BankId { get; set; }

        [Required]
        [MaxLength(100)]
        public string BankName { get; set; }

        [Required]
        [MaxLength(100)]
        public string BankAddress { get; set; }

        [Required]
        [MaxLength(15)]

        public string IFSCCode { get; set; }
    }
}
