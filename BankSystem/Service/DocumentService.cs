using BankSystem.DTO;
using BankSystem.Enum;
using BankSystem.Model;
using BankSystem.Repository.IRepository;
using BankSystem.Service.IService;

namespace BankSystem.Service
{

    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository documentRepository;
        private readonly IUserRepository userRepository;

        public DocumentService(
            IDocumentRepository documentRepository,
            IUserRepository userRepository)
        {
            this.documentRepository = documentRepository;
            this.userRepository = userRepository;
        }

        // ✅ Upload a document for a specific client
        public async Task<Document> UploadDocumentAsync(int clientId, DocumentDto documentDto)
        {
            var user = await userRepository.GetById(clientId);
            if (user == null || user.UserType != UserType.Client)
                throw new Exception("Invalid client.");

            var document = new Document
            {
                UserId = clientId,
                DocumentName = documentDto.DocumentName,
                DocumentType = documentDto.DocumentType,
                UploadDate = DateTime.Now,
                DocumentVerifiedStatus = DocumentVerifiedStatus.Pending
            };

            await documentRepository.AddDocument(document);
            return document;
        }

        // ✅ Get all documents uploaded by a client
        public async Task<IEnumerable<Document>> GetDocumentsByClientIdAsync(int clientId)
        {
            return await documentRepository.GetDocumentsByClientId(clientId);
        }

        // ✅ Get a single document by ID
        public async Task<Document?> GetDocumentByIdAsync(int documentId)
        {
            return await documentRepository.GetDocumentById(documentId);
        }

        // ✅ Approve a document (BankUser action)
        public async Task ApproveDocumentAsync(int documentId)
        {
            var document = await documentRepository.GetDocumentById(documentId);
            if (document == null)
                throw new Exception("Document not found.");

            document.DocumentVerifiedStatus = DocumentVerifiedStatus.Approved;
            await documentRepository.UpdateDocument(document);
        }

        // ✅ Reject a document (BankUser action)
        public async Task RejectDocumentAsync(int documentId, string reason)
        {
            var document = await documentRepository.GetDocumentById(documentId);
            if (document == null)
                throw new Exception("Document not found.");

            document.DocumentVerifiedStatus = DocumentVerifiedStatus.Rejected;

            // Optional: Store rejection reason if your model supports it
            // document.RejectionReason = reason;

            await documentRepository.UpdateDocument(document);
        }

        // ✅ Delete a document (optional admin/bank action)
        public async Task DeleteDocumentAsync(int documentId)
        {
            var document = await documentRepository.GetDocumentById(documentId);
            if (document == null)
                throw new Exception("Document not found.");

            await documentRepository.DeleteDocument(document);
        }
    }
}
