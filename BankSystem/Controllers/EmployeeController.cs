using BankSystem.DTO;
using BankSystem.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ISalaryDisbursementService salaryservice;

        public EmployeeController(ISalaryDisbursementService salaryservice)
        {
            this.salaryservice = salaryservice;
        }

        [HttpGet("SalarySlips/{employeeid}")]

        public async Task<IActionResult> GetSalarySlips(int employeeid)
        {
            var salaryslips = await salaryservice.GetSalariesByEmployeeIdAsync(employeeid);
            return Ok(salaryslips);
        }
    }

}
