using BankSystem.Enum;

namespace BankSystem.DTO
{
    public class EmployeeDto
    {
        public string EmployeeName { get; set; }
        public string AccountNumber { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; } = EmployeeStatus.Approved;
    }
}

