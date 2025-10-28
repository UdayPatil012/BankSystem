using BankSystem.Data;
using BankSystem.Model;
using BankSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly BankContext context;

        public UserRepository(BankContext context) => this.context = context;

        public async Task<IEnumerable<User>> GetAll()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<User?> GetById(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task Add(User user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            context.Users.Update(user);
            await context.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }
    }
}
