using BankSystem.DTO;
using BankSystem.Model;
using BankSystem.Repository.IRepository;
using BankSystem.Service.IService;

namespace BankSystem.Service
{
    public class BeneficiaryService : IBeneficiaryService
    {
        private readonly IBeneficiaryRepository beneficiaryRepository;

        public BeneficiaryService(IBeneficiaryRepository beneficiaryRepository)
        {
            this.beneficiaryRepository = beneficiaryRepository;
        }

        // ✅ Get a single beneficiary by ID (for viewing details)
        public async Task<Beneficiary?> GetBeneficiaryByIdAsync(int beneficiaryId)
        {
            var getbeneficiary = await beneficiaryRepository.GetBeneficiaryById(beneficiaryId);
            if (getbeneficiary == null) throw new InvalidOperationException("Beneficiary not found");
            return getbeneficiary;
        }

        // ✅ Get all beneficiaries linked to a specific client (for viewing list)
        public async Task<IEnumerable<Beneficiary>> GetAllBeneficiariesByClientAsync(int clientId)
        {
            //return await beneficiaryRepository.GetBeneficiariesByClientId(clientId);
            var beneficiaries = await beneficiaryRepository.GetBeneficiariesByClientId(clientId);
            if (!beneficiaries.Any()) throw new InvalidOperationException("No beneficiaries found for this client");
            return beneficiaries;
        }
    }
}
