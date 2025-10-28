using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Model
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }

        [ForeignKey("User")]
        public int GeneratedByUserId { get; set; }
        public User User { get; set; }

        [Required]
        public string ReportType { get; set; }

        public DateTime GeneratedOn { get; set; } = DateTime.Now;

        public string? Content { get; set; }
    }
}
