using BankSystem.DTO;
using BankSystem.Model;
using BankSystem.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperAdminController : ControllerBase
    {
        private readonly ISuperAdminService superAdminService;

        public SuperAdminController(ISuperAdminService superAdminService)
        {
            this.superAdminService = superAdminService;
        }

        // GET: api/SuperAdmin/users
        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await superAdminService.GetAllUSersAsync();
            return Ok(users);
        }

        // POST: api/SuperAdmin/reports
        [HttpPost("reports")]
        public async Task<IActionResult> GenerateReport([FromBody] ReportDto reportDto)
        {
            var report = new Report
            {
                ReportType = reportDto.ReportType,
                Content = reportDto.Content,
                GeneratedByUserId = 1 // SuperAdmin hardcoded ID
            };

            var createdReport = await superAdminService.GenerateReport(report);
            return CreatedAtAction(nameof(GetReportById), new { id = createdReport.ReportId }, createdReport);
        }

        // GET: api/SuperAdmin/reports/{id}
        [HttpGet("reports/{id}")]
        public async Task<IActionResult> GetReportById(int id)
        {
            var report = await superAdminService.GetReportById(id);
            if (report == null) return NotFound();
            return Ok(report);
        }

        [HttpGet("reports")]
        public async Task<IActionResult> GetAllReports()
        {
            var reports = await superAdminService.GetAllReportsAsync();
            return Ok(reports);
        }
    }
}
