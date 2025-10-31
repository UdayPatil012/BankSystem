using BankSystem.Enum;
using System.ComponentModel.DataAnnotations;

namespace BankSystem.DTO
{
    public class ClientDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public UserType UserType { get; set; } = UserType.Client;

        public string CompanyName { get; set; }

        public string UserAddress { get; set; }

        public double balance { get; set; }

        public DocumentType? DocumentType { get; set; }

        public string? DocumentUrl { get; set; }
    }
}
