using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BankSystem.Enum;

namespace BankSystem.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [ForeignKey("Bank")]
        public int? BankId { get; set; }
        public Bank? Bank { get; set; }

        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public UserType UserType { get; set; }

        public ClientStatus? ClientStatus { get; set; }

        [MaxLength(100)]
        public string? CompanyName { get; set; }

        public string? UserAddress { get; set; }

        public double? Balance { get; set; }


    }
}
