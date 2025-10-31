using BankSystem.DTO;
using BankSystem.Model;
using BankSystem.Service;
using BankSystem.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BankUserController : ControllerBase
    {
        private readonly IBankUserService _bankUserService;

        public BankUserController(IBankUserService bankUserService)
        {
            _bankUserService = bankUserService;
        }

        //----------------------- Employee Management -----------------------
        [Authorize]
        [HttpGet("Employee/Client/{clientId}")]
        public async Task<IActionResult> GetEmployeesByClientId(int clientId)
        {
            var employees = await _bankUserService.GetEmployeesByClientId(clientId);
            return Ok(employees);
        }

        [HttpGet("Employee/{employeeId}")]
        public async Task<IActionResult> GetEmployeeById(int employeeId)
        {
            var employee = await _bankUserService.GetEmployeeById(employeeId);
            return Ok(employee);
        }

        [HttpPost("Employee/{employeeId}/Approve")]
        public async Task<IActionResult> ApproveEmployee(int employeeId)
        {
            await _bankUserService.ApproveEmployee(employeeId);
            return Ok(new { Message = "Employee approved successfully." });
        }

        [HttpPost("Employee/{employeeId}/Reject")]
        public async Task<IActionResult> RejectEmployee(int employeeId)
        {
            await _bankUserService.RejectEmployee(employeeId);
            return Ok(new { Message = "Employee rejected successfully." });
        }


        //----------------------- Client Management -----------------------

        [HttpGet("Client/All")]
        public async Task<IActionResult> GetClient()
        {
            var result = await _bankUserService.GetAllClientsAsync();
            return Ok(result);
        }

        [HttpGet("Clients/ById/{clientId}")]
        public async Task<IActionResult> GetClientById(int clientId)
        {
            var client = await _bankUserService.GetClientById(clientId);
            return Ok(client);
        }

        [HttpPost("Clients/{clientId}/Approve")]
        public async Task<IActionResult> ApproveClient(int clientId)
        {
            await _bankUserService.ApproveClient(clientId);
            return Ok(new { Message = "Client approved successfully." });
        }

        [HttpPost("Clients/{clientId}/Reject")]
        public async Task<IActionResult> RejectClient(int clientId)
        {
            await _bankUserService.RejectClient(clientId);
            return Ok(new { Message = "Client rejected successfully." });
        }

        [HttpPut("Client/{clientId}/UpdateClient")]

        public async Task<IActionResult> UpdateClient(int clientid, ClientDto clientdto)
        {
            await _bankUserService.UpdateClient(clientid, clientdto);
            return Ok(new { Message = "Client Updated SuccessFully" });
        }

        [HttpDelete("Client/{clientId}/DeleteClient")]

        public async Task<IActionResult> DeleteClient(int clientId)
        {
            await _bankUserService.DeleteClient(clientId);
            return Ok(new { Message = "Client Deleted Successfully" });
        }


        //----------------------- Beneficiary Management -----------------------

        [HttpGet("Beneficiaries/client/{clientId}")]
        public async Task<IActionResult> GetBeneficiariesByClientId(int clientId)
        {
            var beneficiaries = await _bankUserService.GetBeneficiariesByClientId(clientId);
            return Ok(beneficiaries);
        }

        [HttpGet("Beneficiaries/{beneficiaryId}")]
        public async Task<IActionResult> GetBeneficiaryById(int beneficiaryId)
        {
            var beneficiary = await _bankUserService.GetBeneficiaryById(beneficiaryId);
            return Ok(beneficiary);
        }

        [HttpPost("Beneficiaries/{beneficiaryId}/Approve")]
        public async Task<IActionResult> ApproveBeneficiary(int beneficiaryId)
        {
            await _bankUserService.ApproveBeneficiary(beneficiaryId);
            return Ok(new { Message = "Beneficiary approved successfully." });
        }

        [HttpPost("Beneficiaries/{beneficiaryId}/Reject")]
        public async Task<IActionResult> RejectBeneficiary(int beneficiaryId)
        {
            await _bankUserService.RejectBeneficiary(beneficiaryId);
            return Ok(new { Message = "Beneficiary rejected successfully." });
        }

        [HttpPost("AllBeneficiaries")]

        public async Task<IActionResult> GetAllBeneficiaries()
        {
            await _bankUserService.GetAllBeneficiary();
            return Ok();
        }


        //----------------------- Document Management -----------------------

        [HttpGet("Documents/Client/{clientId}")]
        public async Task<IActionResult> GetDocumentsByClientId(int clientId)
        {
            var documents = await _bankUserService.GetDocumentsByClientId(clientId);
            return Ok(documents);
        }

        [HttpGet("Documents/{documentId}")]
        public async Task<IActionResult> GetDocumentById(int documentId)
        {
            var document = await _bankUserService.GetDocumentById(documentId);
            return Ok(document);
        }

        [HttpPost("Documents/{documentId}/Approve")]
        public async Task<IActionResult> ApproveDocument(int documentId)
        {
            await _bankUserService.ApproveDocument(documentId);
            return Ok(new { Message = "Document approved successfully." });
        }

        [HttpPost("Documents/{documentId}/Reject")]
        public async Task<IActionResult> RejectDocument(int documentId)
        {
            await _bankUserService.RejectDocument(documentId);
            return Ok(new { Message = "Document rejected successfully." });
        }


        //----------------------- Payment Management -----------------------


        [HttpGet("GetAllPayments")]
        public async Task<IActionResult> GetAllPayment()
        {
            var pay = await _bankUserService.GetAllPayment();
            return Ok(pay);
        }

        [HttpGet("Payments/Client/{clientId}")]
        public async Task<IActionResult> GetPaymentsByClientId(int clientId)
        {
            var payments = await _bankUserService.GetPaymentsByClientId(clientId);
            return Ok(payments);
        }

        [HttpGet("Payments/{paymentId}")]
        public async Task<IActionResult> GetPaymentById(int paymentId)
        {
            var payment = await _bankUserService.GetPaymentById(paymentId);
            return Ok(payment);
        }

        [HttpPost("Payments/{paymentId}/Approve")]
        public async Task<IActionResult> ApprovePayment(int paymentId)
        {
            await _bankUserService.ApprovePayment(paymentId);
            return Ok(new { Message = "Payment approved successfully." });
        }

        [HttpPost("Payments/{paymentId}/Reject")]
        public async Task<IActionResult> RejectPayment(int paymentId)
        {
            await _bankUserService.RejectPayment(paymentId);
            return Ok(new { Message = "Payment rejected successfully." });
        }




        //----------------------- Salary Disbursement -----------------------

        [HttpGet("GetAllSalary")]

        public async Task<IActionResult> GetAllSalary()
        {
            var salary = await _bankUserService.GetAllSalary();
            return Ok(salary);
        }

        [HttpGet("SalaryDisbursements/Client/{clientId}")]
        public async Task<IActionResult> GetDisbursementsByClientId(int clientId)
        {
            var disbursements = await _bankUserService.GetDisbursementsByClientId(clientId);
            return Ok(disbursements);
        }

        [HttpGet("SalaryDisbursements/{disbursementId}")]
        public async Task<IActionResult> GetDisbursementById(int disbursementId)
        {
            var disbursement = await _bankUserService.GetDisbursementById(disbursementId);
            return Ok(disbursement);
        }

        [HttpPost("SalaryDisbursements/{disbursementId}/Approve")]
        public async Task<IActionResult> ApproveDisbursement(int disbursementId)
        {
            await _bankUserService.ApproveSalaryDisbursement(disbursementId);
            return Ok(new { Message = "Salary disbursement approved successfully." });
        }

        [HttpPost("SalaryDisbursements/{disbursementId}/Reject")]
        public async Task<IActionResult> RejectDisbursement(int disbursementId)
        {
            await _bankUserService.RejectSalaryDisbursement(disbursementId);
            return Ok(new { Message = "Salary disbursement rejected successfully." });
        }
    }
}
