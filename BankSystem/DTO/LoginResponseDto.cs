namespace BankSystem.DTO
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public string UserType { get; set; } // SuperAdmin, BankUser, Client, etc.
    }
}
