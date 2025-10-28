using BankSystem.Data;
using BankSystem.Model;

namespace BankSystem.Repository.JWT
{
    public interface IAuthRepository
    {
        User? GetUserByUserName(string username);
    }
}
