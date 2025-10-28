using BankSystem.Model;

namespace BankSystem.Repository.IRepository
{
    public interface IDocumentRepository
    {
        Task AddDocument(Document document);
        Task<Document?> GetDocumentById(int documentId);
        Task<IEnumerable<Document>> GetDocumentsByClientId(int clientId);
        Task UpdateDocument(Document document);
        Task DeleteDocument(Document document);
        Task ApproveDocument(int documentId);
        Task RejectDocument(int documentId);
    }
}
