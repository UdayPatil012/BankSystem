using BankSystem.Model;

namespace BankSystem.Repository.IRepository
{
    public interface IReportRepository
    {
        Task AddReport(Report report);
        Task<IEnumerable<Report>> GetAllReports();
        Task<Report?> GetReportById(int reportId);
    }
}
