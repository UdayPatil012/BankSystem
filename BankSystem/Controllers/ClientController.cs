using BankSystem.DTO;
using BankSystem.Service;
using BankSystem.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IEmployeeService _employeeService;

        public ClientController(IClientService clientService, IEmployeeService employeeService)
        {
            _clientService = clientService;
            _employeeService = employeeService;
        }

        
        // ------------------- Employees -------------------

        [HttpGet("employees")]
        public async Task<IActionResult> GetEmployees(int clientId, int pageNumber = 1, int pageSize = 10)
        {
            var result = await _clientService.GetMyEmployeesAsync(clientId, pageNumber, pageSize);
            return Ok(result);
        }

        [HttpGet("{clientId}/employees/{employeeId}")]
        public async Task<IActionResult> GetEmployeeById(int clientId, int employeeId)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(employeeId);
            return Ok(employee);
        }

        [HttpPost("{clientId}/employees")]
        public async Task<IActionResult> AddEmployee(int clientId, [FromBody] EmployeeDto employeeDto)
        {
            var result = await _clientService.AddEmployeeAsync(employeeDto, clientId);
            return Ok(result);
        }

        [HttpPut("{clientId}/employees/{employeeId}")]
        public async Task<IActionResult> UpdateEmployee(int employeeId, [FromBody] EmployeeDto employeeDto)
        {
            await _clientService.UpdateEmployeeAsync(employeeDto, employeeId);
            return Ok("Employee updated successfully");
        }

        [HttpDelete("{clientId}/employees/{employeeId}")]
        public async Task<IActionResult> DeleteEmployee(int employeeId)
        {
            await _clientService.DeleteEmployeeAsync(employeeId);
            return Ok("Employee deleted successfully");
        }

        // ------------------- Documents -------------------

        [HttpGet("{clientId}/documents")]
        public async Task<IActionResult> GetMyDocuments(int clientId)
        {
            var documents = await _clientService.GetMyDocumentsAsync(clientId);
            return Ok(documents);
        }

        [HttpPost("{clientId}/documents")]
        public async Task<IActionResult> UploadDocument(int clientId, [FromBody] DocumentDto documentDto)
        {
            var result = await _clientService.UploadDocumentAsync(documentDto, clientId);
            return Ok(result);
        }

        // ------------------- Salary Disbursement -------------------

        [HttpGet("{clientId}/salary-disbursements")]
        public async Task<IActionResult> GetMySalaryDisbursements(int clientId)
        {
            var disbursements = await _clientService.GetMySalaryDisbursementsAsync(clientId);
            return Ok(disbursements);
        }

        [HttpGet("salary-disbursement/{id}")]
        public async Task<IActionResult> GetSalaryDisbursementById(int id)
        {
            var disbursement = await _clientService.GetSalaryDisbursementByIdAsync(id);
            return Ok(disbursement);
        }

        // ------------------- Beneficiaries -------------------

        [HttpGet("{clientId}/beneficiaries")]
        public async Task<IActionResult> GetMyBeneficiaries(int clientId)
        {
            var beneficiaries = await _clientService.GetMyBeneficiariesAsync(clientId);
            return Ok(beneficiaries);
        }

        [HttpGet("beneficiary/{id}")]
        public async Task<IActionResult> GetBeneficiaryById(int id)
        {
            var beneficiary = await _clientService.GetBeneficiaryByIdAsync(id);
            return Ok(beneficiary);
        }

        [HttpPost("{clientId}/beneficiaries")]
        public async Task<IActionResult> AddBeneficiary(int clientId, [FromBody] BeneficiaryDto beneficiaryDto)
        {
            var result = await _clientService.AddBeneficiaryAsync(beneficiaryDto, clientId);
            return Ok(result);
        }

        [HttpPut("{clientId}/beneficiaries/{beneficiaryId}")]
        public async Task<IActionResult> UpdateBeneficiary(int clientId, int beneficiaryId, [FromBody] BeneficiaryDto beneficiaryDto)
        {
            await _clientService.UpdateBeneficiaryAsync(beneficiaryDto, beneficiaryId);
            return Ok("Beneficiary updated successfully");
        }

        [HttpDelete("{clientId}/beneficiaries/{beneficiaryId}")]
        public async Task<IActionResult> DeleteBeneficiary(int clientId, int beneficiaryId)
        {
            await _clientService.DeleteBeneficiaryAsync(beneficiaryId);
            return Ok("Beneficiary deleted successfully");
        }

        // ------------------- Payments -------------------

        [HttpGet("{clientId}/payments")]
        public async Task<IActionResult> GetPaymentsByClientId(int clientId)
        {
            var payments = await _clientService.GetMyPaymentsAsync(clientId);
            return Ok(payments);
        }

        [HttpGet("payment/{id}")]
        public async Task<IActionResult> GetPaymentById(int id)
        {
            var payment = await _clientService.GetPaymentByIdAsync(id);
            return Ok(payment);
        }

        [HttpPost("{clientId}/payments")]
        public async Task<IActionResult> AddPayment(int clientId, [FromQuery] int beneficiaryId, [FromQuery] double amount, [FromQuery] string remarks)
        {
            var result = await _clientService.MakePaymentAsync(clientId, beneficiaryId, amount, remarks);
            return Ok(result);
        }
    }
}
