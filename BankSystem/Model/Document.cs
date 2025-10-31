using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using BankSystem.Enum;

namespace BankSystem.Model
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        [MaxLength(200)]
        public string DocumentName { get; set; }

        [Required]
        public DocumentType DocumentType { get; set; }

        public DateTime UploadDate { get; set; } = DateTime.Now;

        public string? DocumentUrl { get; set; }

        public DocumentVerifiedStatus DocumentVerifiedStatus { get; set; } = DocumentVerifiedStatus.Pending;
    }
}
