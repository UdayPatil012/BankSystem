using BankSystem.Model;
using BankSystem.Repository.IRepository;
using BankSystem.Service.IService;


namespace BankSystem.Service
{
    public class SuperAdminService : ISuperAdminService
    {
        private readonly IUserRepository userrepository;
        private readonly IReportRepository reportRepository;

        public SuperAdminService(IUserRepository userrepository,IReportRepository reportRepository)
        {
            this.userrepository = userrepository;
            this.reportRepository = reportRepository;
        }

        public async Task<IEnumerable<User>> GetAllUSersAsync()
        {
            var user = await userrepository.GetAll();
            return user.Where(u => u.UserId != 1 && u.UserId != 2);
        }

        public async Task<Report> GenerateReport(Report report)
        {
            await reportRepository.AddReport(report);
            return report;
        }

        public async Task<Report?> GetReportById(int reportId)
        {
            return await reportRepository.GetReportById(reportId);
        }

        public async Task<IEnumerable<Report>> GetAllReportsAsync()
        {
            return await reportRepository.GetAllReports();
        }
    }
}
