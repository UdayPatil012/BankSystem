using BankSystem.Model;
namespace BankSystem.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User?> GetById(int id);
        Task Add(User user);
        Task Update(User user);
        Task Delete(User user);
    }
}
