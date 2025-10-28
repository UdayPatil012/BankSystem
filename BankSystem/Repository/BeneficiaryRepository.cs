using BankSystem.Data;
using BankSystem.Model;
using BankSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Repository
{
    public class BeneficiaryRepository : IBeneficiaryRepository
    {
        private readonly BankContext context;

        public BeneficiaryRepository(BankContext context) => this.context = context;

        public async Task AddBeneficiary(Beneficiary beneficiary)
        {
            await context.Beneficiaries.AddAsync(beneficiary);
            await context.SaveChangesAsync();
        }

        public async Task UpdateBeneficiary(Beneficiary beneficiary)
        {
            context.Beneficiaries.Update(beneficiary);
            await context.SaveChangesAsync();
        }

        public async Task DeleteBeneficiary(Beneficiary beneficiary)
        {
            context.Beneficiaries.Remove(beneficiary);
            await context.SaveChangesAsync();
        }

        public async Task<Beneficiary?> GetBeneficiaryById(int beneficiaryId)
        {
            return await context.Beneficiaries.FindAsync(beneficiaryId);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Beneficiary>> GetBeneficiariesByClientId(int clientId)
        {
            return await context.Beneficiaries
                        .Where(b => b.UserId == clientId)
                        .ToListAsync();
        }

        public async Task<IEnumerable<Beneficiary>> GetAllBeneficiaries()
        {
            return await context.Beneficiaries.ToListAsync();
        }
    }
}
