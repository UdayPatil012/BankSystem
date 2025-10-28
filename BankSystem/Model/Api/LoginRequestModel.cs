namespace BankSystem.Model.Api
{
    public class LoginRequestModel
    {
        public string? UserName { get; set; } = string.Empty;

        public string? Password { get; set; }= string.Empty;
    }
}
