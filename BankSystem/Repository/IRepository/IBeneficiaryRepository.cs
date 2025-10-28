using BankSystem.Model;

namespace BankSystem.Repository.IRepository
{
    public interface IBeneficiaryRepository
    {
        Task AddBeneficiary(Beneficiary beneficiary);
        Task UpdateBeneficiary(Beneficiary beneficiary);
        Task DeleteBeneficiary(Beneficiary beneficiary);
        Task<Beneficiary?> GetBeneficiaryById(int beneficiaryId);
        Task<IEnumerable<Beneficiary>> GetBeneficiariesByClientId(int clientId);
        Task<IEnumerable<Beneficiary>> GetAllBeneficiaries();
    }
}
