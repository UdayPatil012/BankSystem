using BankSystem.Enum;

namespace BankSystem.DTO
{
    public class DocumentDto
    {
        public string DocumentName { get; set; }
        public DocumentType DocumentType { get; set; }
        public DocumentVerifiedStatus DocumentVerifiedStatus { get; set; } = DocumentVerifiedStatus.Approved;
    }
}
