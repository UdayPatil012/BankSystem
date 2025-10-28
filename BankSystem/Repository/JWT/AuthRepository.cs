using BankSystem.Data;
using BankSystem.Model;

namespace BankSystem.Repository.JWT
{
    public class AuthRepository : IAuthRepository
    {
        private readonly BankContext context;

        public AuthRepository(BankContext context)
        {
            this.context = context;
        }

        public User? GetUserByUserName(string username)
        {
            return context.Users.FirstOrDefault(x => x.UserName == username);
        }
    }
}
