using BankSystem.Enum;

namespace BankSystem.DTO
{
    public class BeneficiaryDto
    {
        public string BeneficiaryName { get; set; }
        public string AccountNumber { get; set; }

        public BeneficiaryStatus BeneficiaryStatus { get; set; }
    }
}
