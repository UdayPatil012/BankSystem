using BankSystem.Model;

namespace BankSystem.Service.IService
{
    public interface ISuperAdminService
    {
        Task<IEnumerable<User>> GetAllUSersAsync();
        Task<Report> GenerateReport(Report report);
        Task<Report?> GetReportById(int reportId);
        Task<IEnumerable<Report>> GetAllReportsAsync();
    }
}
