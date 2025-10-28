using BankSystem.Enum;

namespace BankSystem.Model.Api
{
    public class LoginResponseModel
    {
        public string? AccessToken { get; set; }= string.Empty;
        public string usertype { get; set; }=string.Empty;
    }
}
