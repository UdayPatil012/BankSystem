using BankSystem.DTO;
using BankSystem.Model;

namespace BankSystem.Service.IService
{
    public interface IBeneficiaryService
    {
        Task<Beneficiary?> GetBeneficiaryByIdAsync(int beneficiaryId);
         Task<IEnumerable<Beneficiary>> GetAllBeneficiariesByClientAsync(int clientId);
    }
}
