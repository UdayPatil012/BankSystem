using BankSystem.DTO;
using BankSystem.Model;
using BankSystem.Repository.IRepository;
using BankSystem.Service.IService;

namespace BankSystem.Service
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            this.reportRepository = reportRepository;
        }

        public async Task<Report> GenerateReportAsync(ReportDto reportDto, int generatedByUserId)
        {
            var report = new Report
            {
                GeneratedByUserId = generatedByUserId,
                ReportType = reportDto.ReportType,
                Content = reportDto.Content,
                GeneratedOn = DateTime.Now
            };

            await reportRepository.AddReport(report);
            return report;
        }

        public async Task<IEnumerable<Report>> GetAllReportsAsync()
        {
            return await reportRepository.GetAllReports();
        }

        public async Task<Report?> GetReportByIdAsync(int reportId)
        {
            return await reportRepository.GetReportById(reportId);
        }
    }
}
