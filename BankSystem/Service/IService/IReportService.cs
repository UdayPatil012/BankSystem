using BankSystem.DTO;
using BankSystem.Model;
using BankSystem.Repository.IRepository;

namespace BankSystem.Service.IService
{
    public interface IReportService
    {
        Task<Report> GenerateReportAsync(ReportDto reportDto, int generatedByUserId);
        Task<IEnumerable<Report>> GetAllReportsAsync();
        Task<Report?> GetReportByIdAsync(int reportId);
    }
}
