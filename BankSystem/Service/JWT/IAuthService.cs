using BankSystem.Model.Api;

namespace BankSystem.Service.JWT
{
    public interface IAuthService
    {
        Task<LoginResponseModel?> AuthenticateAsync(LoginRequestModel model);
    }
}
