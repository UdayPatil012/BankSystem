using BankSystem.Model;
namespace BankSystem.Repository.IRepository
{
    public interface IBankRepository
    {
        public Task<IEnumerable<Bank>> GetBank();

        public Task UpdateBank(Bank bank);
    }
}
