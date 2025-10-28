using BankSystem.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BankSystem.Enum;

namespace BankSystem.Model
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        [MaxLength(100)]

        public string EmployeeName { get; set; }

        [Required]
        public double Salary { get; set; }

        [Required]
        [MaxLength(100)]

        public string AccountNumber { get; set; }

        public EmployeeStatus EmployeeStatus { get; set; }= EmployeeStatus.Pending;
    }
}
