using BankSystem.Data;
using BankSystem.Model;
using BankSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly BankContext context;

        public ReportRepository(BankContext context) => this.context = context;

        public async Task AddReport(Report report)
        {
            await context.Reports.AddAsync(report);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Report>> GetAllReports()
        {
            return await context.Reports.ToListAsync();
        }

        public async Task<Report?> GetReportById(int reportId)
        {
            return await context.Reports.FindAsync(reportId);
        }
    }
}

