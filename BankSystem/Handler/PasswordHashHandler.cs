using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.Threading.Tasks.Dataflow;

namespace BankSystem.Handler
{
    public static class PasswordHashHandler
    {
        private const int Iterations = 10000;  // PBKDF2 iteration count
        private const int SaltSize = 128 / 8;  // 128-bit salt
        private const int KeySize = 256 / 8;   // 256-bit subkey

        private static readonly RandomNumberGenerator Rng = RandomNumberGenerator.Create();

        // ----------------- Hash Password -----------------
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("Password cannot be null or empty");

            // Generate salt
            byte[] salt = new byte[SaltSize];
            Rng.GetBytes(salt);

            // Derive subkey (hash)
            byte[] subkey = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: Iterations,
                numBytesRequested: KeySize
            );

            // Format: iteration + salt + subkey
            byte[] outputBytes = new byte[4 + SaltSize + KeySize];
            Buffer.BlockCopy(BitConverter.GetBytes(Iterations), 0, outputBytes, 0, 4);
            Buffer.BlockCopy(salt, 0, outputBytes, 4, SaltSize);
            Buffer.BlockCopy(subkey, 0, outputBytes, 4 + SaltSize, KeySize);

            return Convert.ToBase64String(outputBytes);
        }

        // ----------------- Verify Password -----------------
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return password == hashedPassword;
        }
    }
}
