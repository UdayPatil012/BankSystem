using BankSystem.Data;
using BankSystem.Repository.IRepository;
using BankSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly BankContext context;

        public DocumentRepository(BankContext context) => this.context = context;
        public async Task AddDocument(Document document)
        {
            await context.Documents.AddAsync(document);
            await context.SaveChangesAsync();
        }

        public async Task ApproveDocument(int documentId)
        {
            var document = await context.Documents.FindAsync(documentId);

            if (document != null)
            {
                document.DocumentVerifiedStatus = Enum.DocumentVerifiedStatus.Approved;
                context.Documents.Update(document);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteDocument(Document document)
        {
            context.Documents.Remove(document);
            await context.SaveChangesAsync();
        }

        public async Task<Document?> GetDocumentById(int documentId)
        {
            return await context.Documents.FindAsync(documentId);
        }

        public async Task<IEnumerable<Document>> GetDocumentsByClientId(int clientId)
        {
            return await context.Documents.Where(d => d.UserId == clientId).ToListAsync();
        }

        public async Task RejectDocument(int documentId)
        {
            var document = await context.Documents.FindAsync(documentId);

            if (document != null)
            {
                document.DocumentVerifiedStatus = Enum.DocumentVerifiedStatus.Rejected;
                context.Documents.Update(document);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateDocument(Document document)
        {
            context.Documents.Update(document);
            await context.SaveChangesAsync();
        }
    }
}
