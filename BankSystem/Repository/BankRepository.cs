using BankSystem.Data;
using BankSystem.Model;
using BankSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Repository
{
    public class BankRepository : IBankRepository
    {
        private readonly BankContext context;

        public BankRepository(BankContext context) => this.context = context;
        public async Task<IEnumerable<Bank>> GetBank()
        {
            return await context.Banks.ToListAsync();
        }

        public async Task UpdateBank(Bank bank)
        {
            context.Banks.Update(bank);
            await context.SaveChangesAsync();
        }
    }
}
