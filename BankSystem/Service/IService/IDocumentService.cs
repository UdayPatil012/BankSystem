using BankSystem.DTO;
using BankSystem.Model;

namespace BankSystem.Service.IService
{
    public interface IDocumentService
    {
        Task<Document> UploadDocumentAsync(int clientId, DocumentDto documentDto);
        Task<IEnumerable<Document>> GetDocumentsByClientIdAsync(int clientId);
        Task<Document?> GetDocumentByIdAsync(int documentId);
        Task ApproveDocumentAsync(int documentId);
        Task RejectDocumentAsync(int documentId, string reason);
    }
}
